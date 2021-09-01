using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface ICustomerRepository: IAsyncRepository<Customer>
    {
        Task<Customer> GetUserByEmail(string email);
        Task<IEnumerable<Customer>> Get30Customers();
        Task<Customer> GetCustomerDetail(int id);
    }
}
