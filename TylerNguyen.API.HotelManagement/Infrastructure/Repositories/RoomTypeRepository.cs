using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RoomTypeRepository : EfRepository<RoomType>, IRoomTypesRepository
    {
        public RoomTypeRepository(HotelManagementDbContext dbContext): base(dbContext)
        {

        }
        public async Task<IEnumerable<RoomType>> GetAllRoomTypes()
        {
            return await _dbContext.RoomTypes.OrderBy(rt => rt.Id).Take(30).ToListAsync();
        }
        public override async Task<RoomType> GetByIdAsync(int id)
        {
            var rt = await _dbContext.RoomTypes.FirstOrDefaultAsync(r => r.Id == id);
            if (rt == null)
            {
                throw new Exception($"No Room Type Found for the id {id}");
            }
            return rt;
        }
    }
}
