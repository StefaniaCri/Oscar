using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oscar.Models.DTO;
using Oscar.Models.Entities;
using Oscar.Repositories.ProductRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Oscar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _repository;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository repository, IWebHostEnvironment env, IMapper mapper)
        {
            _repository = repository;
            _env = env;
            _mapper = mapper;
        }

        //adaugarea unui nou produs in bd
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            _repository.Create(product);
            await _repository.SaveAsync();
            return Ok(product);

        }

        //lisatrea tuturor produselor
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _repository.GetAll().ToListAsync();
            var productsDTO = _mapper.Map<List<ProductDTO>>(products);
            return Ok(productsDTO);
        }

        //listarea produselor care au pretul mai mic decat un pret dat ca parametru
        [HttpGet("{price}")]
        public async Task<IActionResult> GetAllProductsWithPriceSmaller(decimal price)
        {
            var products = await _repository.GetAll().Where(p => p.Price < price).ToListAsync();

            var returnProducts = _mapper.Map<List<ProductDTO>>(products);

            return Ok(returnProducts);
        }
    
        //modificarea pretului unui produs
        
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

            return Ok(_mapper.Map<ProductDTO>(product));

        }
        
        //sterge dupa id

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct( int id)
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
