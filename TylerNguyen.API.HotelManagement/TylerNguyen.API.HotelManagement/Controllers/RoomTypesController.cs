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
    public class RoomTypesController : ControllerBase
    {
        private readonly IRoomTypesService _roomTypesService;
        public RoomTypesController(IRoomTypesService roomTypesService)
        {
            _roomTypesService = roomTypesService;
        }
        // GET: api/<RoomTypesController>
        [HttpGet]
        public async Task<IActionResult> GetAllRoomTypes()
        {
            var rt = await _roomTypesService.GetAllTypes();
            if (rt == null)
            {
                return NotFound("No RoomTypes Found.");
            }
            return Ok(rt);
        }

        // POST api/<RoomTypesController>/Add
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddRoomType([FromBody] RoomTypeRequestModel model)
        {
            var rt = await _roomTypesService.AddNewRoomType(model);
            return Ok(rt);
        }

        // PUT api/<RoomTypesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoomType(int id, [FromBody] RoomTypeRequestModel model)
        {
            var rt = await _roomTypesService.UpdateRoomType(id, model);
            return Ok(rt);
        }

        // DELETE api/<RoomTypesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            var rt = await _roomTypesService.DeleteRoomType(id);
            return Ok(rt);
        }
    }
}
