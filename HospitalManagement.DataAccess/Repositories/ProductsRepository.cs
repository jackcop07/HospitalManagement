using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Data.DbContext;
using HospitalManagement.Data.Entities;
using HospitalManagement.DataAccess.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync(string productName)
        {
            return _context.Products.ToList();
        }

        public async Task<ProductEntity> GetProductByProductId(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
        }

        public async Task InsertProductAsync(ProductEntity product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
    }
}
