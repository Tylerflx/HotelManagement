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
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        // GET: api/<RoomsController>
        [HttpGet]
        public async Task<IActionResult> Get30Rooms()
        {
            var rooms = await _roomService.GetAllRooms();
            if (rooms == null)
            {
                return NotFound("No Customers Found.");
            }
            return Ok(rooms);
        }

        // POST api/<RoomsController>
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddNewRoom([FromBody] RoomRequestModel model)
        {
            var room = await _roomService.AddRoom(model);
            return Ok(room);
        }

        // PUT api/<RoomsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] RoomRequestModel model)
        {
            var room = await _roomService.UpdateRoom(id, model);
            return Ok(room);
        }

        // DELETE api/<RoomsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _roomService.DeleteRoom(id);
            return Ok(room);
        }
    }
}
