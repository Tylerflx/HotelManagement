using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Service
    {
        public int ID { get; set; }
        public int? ROOMNO { get; set; }
        public string SDESC { get; set; }
        public decimal? AMOUNT { get; set; }
        public DateTime? ServiceDate { get; set; }

        //many to many
        public Room Rooms { get; set; }
    }
}
