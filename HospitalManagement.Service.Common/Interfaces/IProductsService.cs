using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Service.Common.Dtos;
using HospitalManagement.Service.Common.Dtos.Api;
using HospitalManagement.Service.Common.Dtos.Products;

namespace HospitalManagement.Service.Common.Interfaces
{
    public interface IProductsService
    {
        Task<ApiResponse<IEnumerable<ProductToReturnDto>>> GetProductsAsync(string productName);
        Task<ApiResponse<ProductToReturnDto>> GetProductByIdAsync(int productId);
        Task<ApiResponse<ProductToReturnDto>> InsertProductAsync(ProductToInsertDto product);

    }
}
