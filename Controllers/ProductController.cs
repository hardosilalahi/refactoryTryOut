using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using refactorytryout.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace refactorytryout.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly OrdersContext _context;

        public ProductController(ILogger<ProductController> logger, OrdersContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(){
            var product = _context.Product;

            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = product
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var product = _context.Product.First(i => i.Id == id);

            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = product
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var product = _context.Product.First(i => i.Id == id);

            _context.Product.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }

      [HttpPut("{id}")]
        public IActionResult Put(int id, Product productPut){
            var product = _context.Product.First(i => i.Id == id);

            product.Name = productPut.Name;
            product.Price = productPut.Price;
            product.Created_at = product.Created_at;
            product.Updated_at = DateTime.Now;

            _context.Product.Update(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post(Product product){
            product = new Product{
                Name = product.Name,
                Price = product.Price,
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now
            };
            _context.Product.Add(product);
            _context.SaveChanges();
            return Ok(new {
                message = "success send data", 
                status = true,
                data = product
            });
        }

    }
}
