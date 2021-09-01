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
    public class ServiceRepository : EfRepository<Service> , IServiceRepository
    {
        public ServiceRepository(HotelManagementDbContext dbContext): base(dbContext)
        {

        }

        public async Task<IEnumerable<Service>> Get30Services()
        {
            return await _dbContext.Services.OrderBy(c => c.ID).Take(30).ToListAsync();
        }
        public override async Task<Service> GetByIdAsync(int id)
        {
            var service = await _dbContext.Services.FirstOrDefaultAsync(c => c.ID == id);
            if (service == null)
            {
                throw new Exception($"No Service Found for the id {id}");
            }
            return service;
        }
    }
}
