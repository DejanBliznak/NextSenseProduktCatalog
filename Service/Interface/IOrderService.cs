using Data.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IOrderService
    {
        Task<Order> AddOrder(AddOrderModel addOrderModel);
        Task<PaginatedResponse<OrderViewModel>> GetOrders(int size, int page, int? productId);
        Task<OrderViewModel?> GetOrderDetails(int orderId);
        Task<List<ReportForOrderByProductAndManufacturerModel>?> ReportForOrderByProductAndManufacturer();
        Task<List<ReportForOrderByDateModel>?> ReportForOrderByDate();
    }
}
