using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomResponseModel>> GetAllRooms();

        Task<RoomResponseModel> AddRoom(RoomRequestModel model);

        //update customer info
        Task<RoomResponseModel> UpdateRoom(int id, RoomRequestModel model);
        //delete customer
        Task<string> DeleteRoom(int id);
    }
}
