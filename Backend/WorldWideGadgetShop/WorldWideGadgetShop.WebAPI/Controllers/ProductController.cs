using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldWideGadgetShop.Core.IServices;
using WorldWideGadgetShop.Core.Models;

namespace WorldWideGadgetShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        
        public ProductController(IProductService  productService)
        {
            _productService = productService;
        }
        
        // Create
        [HttpPost]
        public ActionResult<Product> Create([FromBody] Product product)
        {
            try
            {
                return Ok(_productService.CreateProduct(product));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Read
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return _productService.GetAllProducts();
        }

        [HttpGet ("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return _productService.GetProductById(id);
        }
        
        // Update
        [HttpPut("{id}")]
        public ActionResult<Product> Update(int id, [FromBody] Product product)
        {
            try
            {
                if (id != product.Id)
                {
                    return BadRequest("Parameter ID and Product ID has to match.");
                }

                return Ok(_productService.UpdateProduct(product));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // Delete
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            try
            {
                return Ok(_productService.DeleteProductById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}