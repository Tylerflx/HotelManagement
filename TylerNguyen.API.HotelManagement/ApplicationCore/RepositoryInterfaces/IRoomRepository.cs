﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IRoomRepository: IAsyncRepository<Room>
    {
        Task<IEnumerable<Room>> Get30Rooms();
    }
}
