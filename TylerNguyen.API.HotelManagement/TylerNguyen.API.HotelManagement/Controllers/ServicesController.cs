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
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService _servicesService;
        public ServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }
        // GET: api/<ServicesController>
        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _servicesService.Get30Services();
            if (services == null)
            {
                return NotFound("No services Found.");
            }
            return Ok(services);
        }

        // POST api/<ServicesController>
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddNewService([FromBody] ServiceRequestModel model)
        {
            var service = await _servicesService.AddService(model);
            return Ok(service);
        }

        // PUT api/<ServicesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] ServiceRequestModel model)
        {
            var service = await _servicesService.UpdateService(id, model);
            return Ok(service);
        }

        // DELETE api/<ServicesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var customer = await _servicesService.DeleteService(id);
            return Ok(customer);
        }
    }
}
