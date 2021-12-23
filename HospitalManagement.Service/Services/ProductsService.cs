using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductsService(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository
                                  ?? throw new ArgumentNullException(nameof(productsRepository));
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ProductToReturnDto>>> GetProductsAsync(string productName)
        {
            var response = new ApiResponse<IEnumerable<ProductToReturnDto>>();

            try
            {
                var productsFromRepo = await _productsRepository.GetAllProductsAsync(productName);

                var mappedProducts = _mapper.Map<IEnumerable<ProductToReturnDto>>(productsFromRepo);

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
                var productFromRepo = await _productsRepository.GetEntityByEntityId(productId);

                if (productFromRepo is not null)
                {

                    response.Data = _mapper.Map<ProductToReturnDto>(productFromRepo);
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
                var productToInsert = _mapper.Map<ProductEntity>(product);

                await _productsRepository.InsertEntityAsync(productToInsert);

                response.Data = _mapper.Map<ProductToReturnDto>(productToInsert);

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
