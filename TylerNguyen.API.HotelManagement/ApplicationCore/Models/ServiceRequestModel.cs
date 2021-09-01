using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class ServiceRequestModel
    {
        public int? ROOMNO { get; set; }
        public string SDESC { get; set; }
        public decimal? AMOUNT { get; set; }
        public DateTime? ServiceDate { get; set; }
    }
}
