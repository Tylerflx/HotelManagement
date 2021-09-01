using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IServicesService
    {
        Task<IEnumerable<ServiceResponseModel>> Get30Services();
        Task<ServiceResponseModel> AddService(ServiceRequestModel model);
        //update customer info
        Task<ServiceResponseModel> UpdateService(int id, ServiceRequestModel model);
        //delete customer
        Task<string> DeleteService(int id);

    }
}
