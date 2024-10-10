using Data.Contex;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implemantation
{
    public class ProductService : IProductService
    {
        public readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }
        public async Task<Product?> GetProductDetails(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            return product;
        }


    }
}
