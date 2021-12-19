using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Data.Entities;
using HospitalManagement.DataAccess.Common.Interfaces;
using HospitalManagement.Service.Common.Dtos.Api;
using HospitalManagement.Service.Common.Dtos.Products;
using HospitalManagement.Service.Common.Interfaces;

namespace HospitalManagement.Service.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository
                ?? throw new ArgumentNullException(nameof(productsRepository));
        }

        public async Task<ApiResponse<IEnumerable<ProductToReturnDto>>> GetProductsAsync(string productName)
        {
            var response = new ApiResponse<IEnumerable<ProductToReturnDto>>();

            try
            {
                var productsFromRepo = await _productsRepository.GetAllProductsAsync(productName);

                var mappedProducts = productsFromRepo.Select(productEntity => new ProductToReturnDto { Id = productEntity.Id, Name = productEntity.Name }).ToList();

                response.Data = mappedProducts;
                return response;
            }
            catch (Exception e)
            {
                response.Error = e.Message;
                return response;
            }
        }

        public async Task<ApiResponse<ProductToReturnDto>> GetProductByIdAsync(int productId)
        {
            var response = new ApiResponse<ProductToReturnDto>();

            try
            {
                var productFromRepo = await _productsRepository.GetProductByProductId(productId);

                if (productFromRepo is not null)
                {
                    var mappedProduct = new ProductToReturnDto
                    {
                        Id = productFromRepo.Id,
                        Name = productFromRepo.Name
                    };
                    response.Data = mappedProduct;
                }
                else
                {
                    response.Data = null;
                }

                return response;
            }
            catch (Exception e)
            {
                response.Error = e.Message;
                return response;
            }
        }

        public async Task<ApiResponse<ProductToReturnDto>> InsertProductAsync(ProductToInsertDto product)
        {
            var response = new ApiResponse<ProductToReturnDto>();

            try
            {
                var productToInsert = new ProductEntity
                {
                    Name = product.Name
                };

                await _productsRepository.InsertProductAsync(productToInsert);

                var productToReturn = new ProductToReturnDto
                {
                    Id = productToInsert.Id,
                    Name = productToInsert.Name
                };


                response.Data = productToReturn;

                return response;
            }
            catch (Exception e)
            {
                response.Error = e.Message;
                return response;
            }
        }
    }
}
