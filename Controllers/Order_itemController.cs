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
    [Route("order_item")]
    public class Order_itemController : ControllerBase
    {

        private readonly ILogger<Order_itemController> _logger;
        private readonly OrdersContext _context;

        public Order_itemController(ILogger<Order_itemController> logger, OrdersContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(){
            var order_item = _context.Order_item;

            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = order_item
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var order_item = _context.Order_item.First(i => i.Id == id);

            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = order_item
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var order_item = _context.Order_item.First(i => i.Id == id);

            _context.Order_item.Remove(order_item);
            _context.SaveChanges();
            return Ok(order_item);
        }

        [HttpPost]
        public IActionResult Post(Order_item order_item){
            order_item = new Order_item{
                OrderId = order_item.OrderId,
                ProductId = order_item.ProductId,
                Quantity = order_item.Quantity
            };
            _context.Order_item.Add(order_item);
            _context.SaveChanges();
            return Ok(new {
                message = "success send data", 
                status = true,
                data = order_item
            });
        }

    }
}
