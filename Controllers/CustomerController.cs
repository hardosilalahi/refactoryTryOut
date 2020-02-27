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
    [Route("customer")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private readonly OrdersContext _context;

        public CustomerController(ILogger<CustomerController> logger, OrdersContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(){
            var customer = _context.Customer;

            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = customer
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var customer = _context.Customer.First(i => i.Id == id);

            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = customer
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var customer = _context.Customer.First(i => i.Id == id);

            _context.Customer.Remove(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        // [HttpPatch("{id}")]
        // public IActionResult Put(int id, Order_status status){
        //     var order = _context.Order.First(i => i.Id == id);
        //     order.Status = status;
        //     _context.SaveChanges();
        //     return Ok(order);
        // }

        [HttpPost]
        public IActionResult Post(string fullName, string username, string email, string phoneNumber){
            var customer = new Customer{
                Full_name = fullName,
                Username = username,
                Email = email,
                Phone_number = phoneNumber,
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now
            };
            _context.Customer.Add(customer);
            _context.SaveChanges();
            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = customer
            });
        }

    }
}
