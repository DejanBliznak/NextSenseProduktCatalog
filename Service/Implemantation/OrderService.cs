using Data.Contex;
using Data.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implemantation
{
    public class OrderService : IOrderService
    {
        public readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Order> AddOrder(AddOrderModel addOrderModel)
        {
            var order = new Order()
            {
                OrderDate = DateTime.Now,

            };
            order.OrderDetails = addOrderModel.Products.GroupBy(x =>x.ProductId).Select(x => new OrderDetail()
            {
                OrderID = order.ID,
                ProductID = x.Key,
                Quantity = x.Sum(x => x.Quantity),
                UnitPrice = x.Select(x=>x.UnitPrice).FirstOrDefault(),

            }).ToList();

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<OrderViewModel?> GetOrderDetails ( int orderId)
        {
            var order = await _context.Orders.Include(od => od.OrderDetails).ThenInclude(p => p.Product)
                 .Where(x => x.ID == orderId)
               .Select(x => new OrderViewModel()
               {
                   ID = x.ID,
                   OrderDate = x.OrderDate,
                   OrderTotal = x.OrderDetails.Sum(od => od.Quantity * od.UnitPrice),
                   orderDetails = x.OrderDetails.Select(y => new OrderDetailsViewModel()
                   {
                       ProductID = y.ProductID,
                       Quantity = y.Quantity,
                       UnitPrice = y.UnitPrice,
                       ProductName = y.Product.Name
                   }).ToList(),
               }).FirstOrDefaultAsync();

            return order;
        }

        public async Task<PaginatedResponse<OrderViewModel>> GetOrders(int size, int page, int? productId)
        {
            
            var orders = await _context.Orders.Include(od => od.OrderDetails).ThenInclude(p => p.Product)
                  .Where(x => productId == null || x.OrderDetails.Any(od => od.ProductID == productId))
                .Select(x => new OrderViewModel()
                {
                    ID = x.ID,
                    OrderDate = x.OrderDate,
                    OrderTotal = x.OrderDetails.Sum(od => od.Quantity * od.UnitPrice),
                    orderDetails = x.OrderDetails.Select(y => new OrderDetailsViewModel()
                    {
                        ProductID = y.ProductID,
                        Quantity = y.Quantity,
                        UnitPrice = y.UnitPrice,
                        ProductName = y.Product.Name
                    }).ToList(),
                })
             .OrderByDescending(x => x.OrderDate)
            .Skip((page - 1) * size).Take(size).ToListAsync();

            var totalRecords = await _context.Orders.Include(od => od.OrderDetails).Where(x => productId == null || x.OrderDetails.Any(od => od.ProductID == productId)).CountAsync();

            return new PaginatedResponse<OrderViewModel>(orders, totalRecords, page, size);
        }

        public async Task<List<ReportForOrderByProductAndManufacturerModel>?> ReportForOrderByProductAndManufacturer()
        {
            var report = await _context.OrderDetails
                .Include(od => od.Product)
                .GroupBy(od => new { od.Product.Name, od.Product.Manufacturer })
                .Select(g => new ReportForOrderByProductAndManufacturerModel()
                {
                    ManufacturerName = g.Key.Manufacturer,
                    ProductName = g.Key.Name,
                    TotalQuantity = g.Sum(od => od.Quantity)
                }).OrderBy(r => r.ManufacturerName).ThenBy(r => r.ProductName).ToListAsync();

            return report;
        }

        public async Task<List<ReportForOrderByDateModel>?> ReportForOrderByDate()
        {
            var report = await _context.Orders
                .SelectMany(o => o.OrderDetails, (o, od) => new
                {
                    OrderDate = o.OrderDate.Date,
                    od.Quantity
                })
                .GroupBy(d => d.OrderDate)
                .Select(g => new ReportForOrderByDateModel()
                {
                    Date = g.Key,
                    TotalQuantity = g.Sum(x => x.Quantity)
                }).OrderByDescending(r => r.Date).ToListAsync();

            return report;
        }
    }
}
