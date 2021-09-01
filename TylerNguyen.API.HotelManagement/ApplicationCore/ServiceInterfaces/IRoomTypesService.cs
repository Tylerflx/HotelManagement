using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IRoomTypesService
    {
        Task<IEnumerable<RoomTypeResponseModel>> GetAllTypes();
        //add
        Task<RoomTypeResponseModel> AddNewRoomType(RoomTypeRequestModel model);
        //update
        Task<RoomTypeResponseModel> UpdateRoomType(int id, RoomTypeRequestModel model);
        //delete
        Task<string> DeleteRoomType(int id);
    }
}
