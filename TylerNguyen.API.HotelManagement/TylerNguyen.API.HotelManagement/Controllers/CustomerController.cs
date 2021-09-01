using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TylerNguyen.API.HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService; //controller will use services
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET api/Customers
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            if (customers == null)
            {
                return NotFound("No Customers Found.");
            }
            return Ok(customers);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult>GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerDetail(id);
            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerRequestModel model)
        {
            var customer = await _customerService.AddCustomer(model);
            return Ok(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerRequestModel model)
        {
            var customer = await _customerService.UpdateCustomer(id,model);
            return Ok(customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerService.DeleteCustomer(id);
            return Ok(customer);
        }
    }
}
