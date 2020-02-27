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
    [Route("order")]
    public class OrderController : ControllerBase
    {

        private readonly ILogger<OrderController> _logger;
        private readonly OrdersContext _context;

        public OrderController(ILogger<OrderController> logger, OrdersContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(){
            var order = _context.Order;

            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = order
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var order = _context.Order.First(i => i.Id == id);

            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = order
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var order = _context.Order.First(i => i.Id == id);

            _context.Order.Remove(order);
            _context.SaveChanges();
            return Ok(order);
        }

        // [HttpPatch("{id}")]
        // public IActionResult Put(int id, Order_status status){
        //     var order = _context.Order.First(i => i.Id == id);
        //     order.Status = status;
        //     order.Updated_at = DateTime.Now;
        //     _context.SaveChanges();
        //     return Ok(order);
        // }
        [HttpPost]
        public IActionResult Post(int custId, Order_status status, int driveId){
            var order = new Order{
                CustomerId = custId,
                Status = status,
                DriverId = driveId,
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now
            };
            _context.Order.Add(order);
            _context.SaveChanges();
            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = order
            });
        }

    }
}
