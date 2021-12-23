using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Data.Entities;

namespace HospitalManagement.DataAccess.Common.Interfaces
{
    public interface IProductsRepository : IBaseRepository<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> GetAllProductsAsync(string productName);

    }
}
