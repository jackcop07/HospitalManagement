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
    public class ProductsRepository : BaseRepository<ProductEntity>, IProductsRepository
    {

        public ProductsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync(string? productName)
        {
            var collection = _context.Products as IQueryable<ProductEntity>;

            if (string.IsNullOrWhiteSpace(productName)) return await collection.ToListAsync();

            productName = productName.Trim();
            collection = collection.Where(
                c => c.Name.Contains(productName));


            return await collection.ToListAsync();
        }
    }
}
