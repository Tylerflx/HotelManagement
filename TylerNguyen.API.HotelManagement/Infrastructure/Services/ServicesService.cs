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
    public class ServicesService : IServicesService
    {
        private readonly IServiceRepository _serviceRepository;
        public ServicesService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<ServiceResponseModel> AddService(ServiceRequestModel model)
        {
            var service = new Service
            {
                ROOMNO = model.ROOMNO,
                SDESC = model.SDESC,
                AMOUNT = model.AMOUNT,
                ServiceDate = model.ServiceDate
            };
            var createService = await _serviceRepository.AddAsync(service);
            var serviceModel = new ServiceResponseModel
            {
                ID = createService.ID,
                ROOMNO = createService.ROOMNO,
                SDESC = createService.SDESC,
                AMOUNT = createService.AMOUNT,
                ServiceDate = createService.ServiceDate
            };
            return serviceModel;
        }

        public async Task<string> DeleteService(int id)
        {
            var service  = await _serviceRepository.GetByIdAsync(id);
            if ( service == null)
            {
                throw new Exception("Service doesnt exist.");
            }
            await _serviceRepository.DeleteASync(service);
            return "Service deleted successfully!";
        }

        public async Task<IEnumerable<ServiceResponseModel>> Get30Services()
        {
            var services = await _serviceRepository.Get30Services();
            var serviceModel = new List<ServiceResponseModel>();
            foreach (var service in services)
            {
                serviceModel.Add(new ServiceResponseModel
                {
                    ID = service.ID,
                    ROOMNO = service.ROOMNO,
                    SDESC = service.SDESC,
                    AMOUNT = service.AMOUNT,
                    ServiceDate = service.ServiceDate
                });
            }
            return serviceModel;
        }

        public async Task<ServiceResponseModel> UpdateService(int id, ServiceRequestModel model)
        {
            var service = await _serviceRepository.GetByIdAsync(id);
            if (service == null)
            {
                throw new Exception("Service doesnt match");
            }
            service.ROOMNO = model.ROOMNO;
            service.SDESC = model.SDESC;
            service.AMOUNT = model.AMOUNT;
            service.ServiceDate = model.ServiceDate;

            var updateService = await _serviceRepository.UpdateAsync(service);
            var serviceModel = new ServiceResponseModel
            {
                ID = updateService.ID,
                ROOMNO = updateService.ROOMNO,
                SDESC = updateService.SDESC,
                AMOUNT = updateService.AMOUNT,
                ServiceDate = updateService.ServiceDate
            };
            return serviceModel;
        }
    }
}
