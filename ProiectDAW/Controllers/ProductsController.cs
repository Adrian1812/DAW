using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectDAW.DAL;
using ProiectDAW.DAL.Entities.DTOs;
using ProiectDAW.DAL.Entities;
using ProiectDAW.DAL.Repositories.ProductRepository;
using ProiectDAW.DAL.Repositories;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;


        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        //read
        [HttpGet("GetProductByName/{name}")]
        public async Task<IActionResult> GetAllProducts([FromRoute] string name)
        {
            var Products = await _repository.GetByName(name);

            return Ok(Products);
        }

        //create
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO dto)
        {
            Product newProduct = new Product();

            newProduct.Name = dto.Name;
            newProduct.Price = dto.Price;
            newProduct.Id = dto.Id;
            newProduct.Orders = dto.Orders;
            newProduct.Dealer = dto.Dealer;
            newProduct.DealerId = dto.DealerId;

            _repository.Create(newProduct);

            await _repository.SaveAsync();

            return Ok(new ProductDTO(newProduct));
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var Product = await _repository.GetByIdAsync(id);
            _repository.Delete(Product);
            await _repository.SaveAsync();

            return Ok(Product);
        }

        [HttpPut("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product updatedProduct, [FromRoute] int id)
        {
            var Product = await _repository.GetByIdAsync(id);
            _repository.Delete(Product);
            _repository.Create(updatedProduct);
            await _repository.SaveAsync();

            return Ok(updatedProduct);
        }
    }
}
