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
    public class RoomRepository : EfRepository<Room>, IRoomRepository
    {
        public RoomRepository(HotelManagementDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<Room>> Get30Rooms()
        {
            return await _dbContext.Rooms.OrderBy(c => c.Id).Take(30).ToListAsync();
        }
        public override async Task<Room> GetByIdAsync(int id)
        {
            var room = await _dbContext.Rooms.FirstOrDefaultAsync(c => c.Id == id);
            if (room == null)
            {
                throw new Exception($"No Room Found for the id {id}");
            }
            return room;
        }
    }
}
