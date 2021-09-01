using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponseModel>> GetAllCustomers();

        Task<CustomerResponseModel> AddCustomer(CustomerRequestModel model);

        //update customer info
        Task<CustomerResponseModel> UpdateCustomer(int id, CustomerRequestModel model);
        //delete customer
        Task<string> DeleteCustomer(int id);

        Task<CustomerResponseModel> GetCustomerById(int id);
        Task<CustomerDetailResponseModel> GetCustomerDetail(int id);



    }
}
