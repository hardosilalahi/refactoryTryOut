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
    [Route("driver")]
    public class DriverController : ControllerBase
    {

        private readonly ILogger<DriverController> _logger;
        private readonly OrdersContext _context;

        public DriverController(ILogger<DriverController> logger, OrdersContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(){
            var driver = _context.Driver;

            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = driver
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var driver = _context.Driver.First(i => i.Id == id);

            return Ok(new {
                message = "success retrieve data", 
                status = true,
                data = driver
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var driver = _context.Driver.First(i => i.Id == id);

            _context.Driver.Remove(driver);
            _context.SaveChanges();
            return Ok(driver);
        }

      [HttpPut("{id}")]
        public IActionResult Put(int id, Driver driverPut){
            var driver = _context.Driver.First(i => i.Id == id);

            driver.Full_name = driverPut.Full_name;
            driver.Phone_number = driverPut.Phone_number;
            driver.Created_at = driver.Created_at;
            driver.Updated_at = DateTime.Now;

            _context.Driver.Update(driver);
            _context.SaveChanges();
            return Ok(driver);
        }

        [HttpPost]
        public IActionResult Post(Driver driver){
            driver = new Driver{
                Full_name = driver.Full_name,
                Phone_number = driver.Phone_number,
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now
            };
            _context.Driver.Add(driver);
            _context.SaveChanges();
            return Ok(new {
                message = "success send data", 
                status = true,
                data = driver
            });
        }

    }
}
