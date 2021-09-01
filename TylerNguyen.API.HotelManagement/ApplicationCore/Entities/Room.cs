using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int? RTCODE { get; set; }
        public bool? STATUS { get; set; }

        //one to one
        //public Customer Customers { get; set; }
        public RoomType RoomTypes { get; set; }
        //many to many
        public ICollection<Service> Services { get; set; }


    }
}
