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
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(HotelManagementDbContext dbContext): base(dbContext)
        {

        }

        public async Task<IEnumerable<Customer>> Get30Customers()
        {
            return await _dbContext.Customers.OrderBy(c => c.Id).Take(30).ToListAsync();

        }

        public async Task<Customer> GetUserByEmail(string email)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.EMAIL == email);
            return customer;
        }
        public override async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                throw new Exception($"No Customer Found for the id {id}");
            }
            return customer;
        }

        public async Task<Customer> GetCustomerDetail(int id)
        {
            var customer = await _dbContext.Customers.Include(c => c.Rooms).Include(c => c.Rooms.Services).Include(c => c.Rooms.RoomTypes).FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                throw new Exception($"No Customer Found for the id {id}");
            }
            return customer;
        }
    }
}
