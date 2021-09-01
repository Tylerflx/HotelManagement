using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IServiceRepository : IAsyncRepository<Service>
    {
        Task<IEnumerable<Service>> Get30Services();
    }
}
