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
    public class RoomTypeService : IRoomTypesService
    {
        private readonly IRoomTypesRepository _roomTypesRespository;   //connect to db logic
        public RoomTypeService(IRoomTypesRepository roomTypesRepository)
        {
            _roomTypesRespository = roomTypesRepository;
        }

        public async  Task<RoomTypeResponseModel> AddNewRoomType(RoomTypeRequestModel model)
        {
            var rt = new RoomType
            {
                RTDESC = model.RTDESC,
                Rent = model.Rent
            };
            var createRt = await _roomTypesRespository.AddAsync(rt);
            var rtModel = new RoomTypeResponseModel
            {
                Id = createRt.Id,
                RTDESC = createRt.RTDESC,
                Rent = createRt.Rent
            };
            return rtModel;
        }

        public async Task<string> DeleteRoomType(int id)
        {
            var rt = await _roomTypesRespository.GetByIdAsync(id);
            if (rt == null)
            {
                throw new Exception("Room Type doesnt exist");
            }
            await _roomTypesRespository.DeleteASync(rt);
            return "Room Type has been deleted!";
        }

        public async Task<IEnumerable<RoomTypeResponseModel>> GetAllTypes()
        {
            var rts = await _roomTypesRespository.GetAllRoomTypes();
            var rtModel = new List<RoomTypeResponseModel>();
            foreach (var room in rts)
            {
                rtModel.Add(new RoomTypeResponseModel
                {
                    Id = room.Id,
                    RTDESC = room.RTDESC,
                    Rent = room.Rent
                });
            }
            return rtModel;
        }

        public async Task<RoomTypeResponseModel> UpdateRoomType(int id, RoomTypeRequestModel model)
        {
            var rt = await _roomTypesRespository.GetByIdAsync(id);
            if (rt == null)
            {
                throw new Exception("Room Type id doesnt match");
            }
            //update rt data
            rt.RTDESC = model.RTDESC;
            rt.Rent = model.Rent;
            //update method
            var updateRT = await _roomTypesRespository.UpdateAsync(rt);
            //response message
            var rtModel = new RoomTypeResponseModel
            {
                Id = updateRT.Id,
                RTDESC = updateRT.RTDESC,
                Rent = updateRT.Rent
            };
            return rtModel;

        }
    }
}
