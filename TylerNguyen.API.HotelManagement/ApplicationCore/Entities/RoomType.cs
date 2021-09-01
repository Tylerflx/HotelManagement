using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class RoomType
    {
        public int Id { get; set; }
        public string RTDESC { get; set; }
        public decimal? Rent { get; set; }

        //one to one
        //public Room Rooms { get; set; }
    }
}
