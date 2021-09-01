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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerResponseModel> AddCustomer(CustomerRequestModel model)
        {
            //check if the customer already exist with the email
            var dbCustomer = await _customerRepository.GetUserByEmail(model.EMAIL);
            if (dbCustomer != null)
            {
                //if exist
                //throw exception
                throw new Exception("Email exist");     //could upgrade to custom exception
            }
            //if user not exist in the db
            //then add customer
            var customer = new Customer
            {
                ROOMNO = model.ROOMNO,
                CNAME = model.CNAME,
                ADDRESS = model.ADDRESS,
                PHONE = model.PHONE,
                EMAIL = model.EMAIL,
                CHECKIN = model.CHECKIN,
                TotalPERSONS = model.TotalPERSONS,
                BookingDays = model.BookingDays,
                ADVANCE = model.ADVANCE
            };
            var createCustomer = await _customerRepository.AddAsync(customer);  //add customer to db
            //this is the response of the action
            var customerModel = new CustomerResponseModel
            {
                Id = createCustomer.Id,
                CNAME = createCustomer.CNAME,
                EMAIL = createCustomer.EMAIL,
                ROOMNO = createCustomer.ROOMNO,
            };
            return customerModel;
        }

        public async Task<string> DeleteCustomer(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                throw new Exception("Customer doesnt exist.");
            }
            await _customerRepository.DeleteASync(customer);
            return "Customer deleted successfully!";
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAllCustomers()
        {
            var customers = await _customerRepository.Get30Customers();
            var customerModel = new List<CustomerResponseModel>();
            foreach (var customer in customers)
            {
                customerModel.Add(new CustomerResponseModel
                {
                    Id = customer.Id,
                    ROOMNO = customer.ROOMNO,
                    CNAME = customer.CNAME,
                    ADDRESS = customer.ADDRESS,
                    PHONE = customer.PHONE,
                    EMAIL = customer.EMAIL,
                    CHECKIN = customer.CHECKIN,
                    TotalPERSONS = customer.TotalPERSONS,
                    BookingDays = customer.BookingDays,
                    ADVANCE = customer.ADVANCE
                });
            }
            return customerModel;
        }

        public async Task<CustomerResponseModel> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                throw new Exception("Customer doesnt match");
            }
            var customerModel = new CustomerResponseModel
            {
                Id = customer.Id,
                ROOMNO = customer.ROOMNO,
                CNAME = customer.CNAME,
                ADDRESS = customer.ADDRESS,
                PHONE = customer.PHONE,
                EMAIL = customer.EMAIL,
                CHECKIN = customer.CHECKIN,
                TotalPERSONS = customer.TotalPERSONS,
                BookingDays = customer.BookingDays,
                ADVANCE = customer.ADVANCE
            };
            return customerModel;
        }

        public async Task<CustomerDetailResponseModel> GetCustomerDetail(int id)
        {
            var customers = await _customerRepository.GetCustomerDetail(id);
            if (customers == null)
            {
                throw new Exception("Customer doesnt match");
            }
            var customerModel = new CustomerDetailResponseModel
            {
                Id = customers.Id,
                ROOMNO = customers.ROOMNO,
                CNAME = customers.CNAME,
                ADDRESS = customers.ADDRESS,
                PHONE = customers.PHONE,
                EMAIL = customers.EMAIL,
                CHECKIN = customers.CHECKIN,
                TotalPERSONS = customers.TotalPERSONS,
                BookingDays = customers.BookingDays,
                ADVANCE = customers.ADVANCE
            };
            customerModel.Rooms = new Room
            {
                Id = customers.Rooms.Id,
                RTCODE = customers.Rooms.RTCODE,
                STATUS = customers.Rooms.STATUS,
            };
            customerModel.Rooms.RoomTypes = new RoomType
            {
                Id = customers.Rooms.RoomTypes.Id,
                RTDESC = customers.Rooms.RoomTypes.RTDESC,
                Rent = customers.Rooms.RoomTypes.Rent
            };
            customerModel.Rooms.Services = new List<Service>();
            foreach (var service in customers.Rooms.Services)
            {
                customerModel.Rooms.Services.Add(new Service
                {
                    ID = service.ID,
                    SDESC = service.SDESC,
                    AMOUNT = service.AMOUNT,
                    ServiceDate = service.ServiceDate
                });
            }

            return customerModel;
        }

        public async Task<CustomerResponseModel> UpdateCustomer(int id, CustomerRequestModel model)
        {
            //if id matched then update his/her info
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                throw new Exception("Customer doesnt match");
            }
            customer.ROOMNO = model.ROOMNO;
            customer.CNAME = model.CNAME;
            customer.ADDRESS = model.ADDRESS;
            customer.PHONE = model.PHONE;
            customer.EMAIL = model.EMAIL;
            customer.CHECKIN = model.CHECKIN;
            customer.TotalPERSONS = model.TotalPERSONS;
            customer.BookingDays = model.BookingDays;
            customer.ADVANCE = model.ADVANCE;

            var updatedCustomer = await _customerRepository.UpdateAsync(customer);
            //this is the response of the action
            var customerModel = new CustomerResponseModel
            {
                Id = updatedCustomer.Id,
                CNAME = updatedCustomer.CNAME,
                EMAIL = updatedCustomer.EMAIL,
                ROOMNO = updatedCustomer.ROOMNO,
                TotalPERSONS = updatedCustomer.TotalPERSONS,
                BookingDays = updatedCustomer.BookingDays,
                ADVANCE = updatedCustomer.ADVANCE
            };

            return customerModel;
        }
    }
}
