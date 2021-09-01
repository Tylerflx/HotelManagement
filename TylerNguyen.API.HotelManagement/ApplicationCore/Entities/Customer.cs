using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public int? ROOMNO { get; set; }
        public string CNAME { get; set; }
        public string ADDRESS { get; set; }
        public string PHONE { get; set; }
        public string EMAIL { get; set; }
        public DateTime? CHECKIN { get; set; }
        public int? TotalPERSONS { get; set; }
        public int? BookingDays { get; set; }
        public Decimal? ADVANCE { get; set; }

        //foreign key
        public Room Rooms { get; set; }
    }
}
