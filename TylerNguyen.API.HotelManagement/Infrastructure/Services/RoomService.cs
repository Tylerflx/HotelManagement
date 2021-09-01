using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<RoomResponseModel> AddRoom(RoomRequestModel model)
        {
            var room = new Room
            {
                RTCODE = model.RTCODE,
                STATUS = model.STATUS,
            };
            var createRoom = await _roomRepository.AddAsync(room);
            var roomModel = new RoomResponseModel
            {
                Id = createRoom.Id,
                RTCODE = createRoom.RTCODE,
                STATUS = createRoom.STATUS
            };
            return roomModel;
        }

        public async Task<string> DeleteRoom(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null)
            {
                throw new Exception("Room doesnt exist");
            }
            await _roomRepository.DeleteASync(room);
            return "Room has been deleted!";
        }

        public async Task<IEnumerable<RoomResponseModel>> GetAllRooms()
        {
            var rooms = await _roomRepository.Get30Rooms();
            var roomModel = new List<RoomResponseModel>();
            foreach (var room in rooms)
            {
                roomModel.Add(new RoomResponseModel
                {
                    Id = room.Id,
                    RTCODE = room.RTCODE,
                    STATUS = room.STATUS
                });
            }
            return roomModel;
        }

        public async Task<RoomResponseModel> UpdateRoom(int id, RoomRequestModel model)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null)
            {
                throw new Exception("Room Type id doesnt match");
            }
            //update rt data
            room.RTCODE = model.RTCODE;
            room.STATUS = model.STATUS;
            //update method
            var updateRoom = await _roomRepository.UpdateAsync(room);
            //response message
            var roomModel = new RoomResponseModel
            {
                Id = updateRoom.Id,
                RTCODE = updateRoom.RTCODE,
                STATUS = updateRoom.STATUS,
            };
            return roomModel;
        }
    }
}
