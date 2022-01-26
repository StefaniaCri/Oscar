using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oscar.Models.DTO;
using Oscar.Models.Entities;
using Oscar.Repositories.ProductRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oscar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO dto)
        {
            Product newProduct = new Product();

            newProduct.Name = dto.Name;
            newProduct.Price = dto.Price;

            _repository.Create(newProduct);

            await _repository.SaveAsync();

            return Ok(new ProductDTO(newProduct));

        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _repository.GetAll().ToListAsync();

            var returnProducts = new List<ProductDTO>();

            foreach (var product in products)
            {
                returnProducts.Add(new ProductDTO(product));
            }

            return Ok(returnProducts);
        }

        [HttpGet("{price}")]
        public async Task<IActionResult> GetAllProductsWithPriceSmaller(decimal price)
        {
            var products = await _repository.GetAll().Where(p => p.Price < price).ToListAsync();

            var returnProducts = new List<ProductDTO>();

            foreach (var product in products)
            {
                returnProducts.Add(new ProductDTO(product));
            }

            return Ok(returnProducts);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrice(int id, decimal newprice)
        {
            Product product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound("Product does not exist!");
            }

            product.Price = newprice;

            await _repository.SaveAsync();

            return Ok(new ProductDTO(product));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound("Product does not exist!");
            }

            _repository.Delete(product);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
