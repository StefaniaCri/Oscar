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

        public ProductController(IProductRepository repository, IWebHostEnvironment env)
        {
            _repository = repository;
            _env = env;
        }

        //adaugarea unui nou produs in bd
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO dto)
        {
            Product newProduct = new Product();

            newProduct.Name = dto.Name;
            newProduct.Price = dto.Price;
            newProduct.PhotoFileName = dto.PhotoFileName;
            _repository.Create(newProduct);

            await _repository.SaveAsync();

            return Ok(new ProductDTO(newProduct));

        }

        //lisatrea tuturor produselor
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

        //listarea produselor care au pretul mai mic decat un pret dat ca parametru
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

            return Ok(new ProductDTO(product));

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


        //adaugarea de poze a produselor
        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }

    }
}
