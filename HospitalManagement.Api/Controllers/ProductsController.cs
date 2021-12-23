using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HospitalManagement.Service.Common.Dtos.Products;
using HospitalManagement.Service.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService
                ?? throw new ArgumentNullException(nameof(productsService));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ProductToReturnDto>))]
        [ProducesResponseType(204)]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts([FromQuery] string? productName)
        {
            var response = await _productsService.GetProductsAsync(productName);

            if (!string.IsNullOrEmpty(response.Error))
            {
                return StatusCode(500, response.Error);
            }

            if (!response.Data.Any())
            {
                return NoContent();
            }

            return Ok(response.Data);
        }

        [HttpGet("{productId}", Name = "GetProductByProductId")]
        [ProducesResponseType(200, Type = typeof(ProductToReturnDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductToReturnDto>> GetProductById(int productId)
        {
            var response = await _productsService.GetProductByIdAsync(productId);

            if (!string.IsNullOrEmpty(response.Error))
            {
                return StatusCode(500, response.Error);
            }

            if (response.Data is null)
            {
                return NotFound();
            }

            return Ok(response.Data);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<ProductToReturnDto>> Post([FromBody] ProductToInsertDto product)
        {
            var result = await _productsService.InsertProductAsync(product);

            if (result.Error is null)
            {
                return CreatedAtRoute("GetProductByProductId", new { productId = result.Data.Id }, result.Data);
            }

            return StatusCode(500, result.Error);
        }


        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
