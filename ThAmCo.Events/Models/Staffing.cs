using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class Staffing
    {

        public Staffing()
        {
        }

        public int EventId { get; set; }

        public int StaffId { get; set; }

        public Staff Staff { get; set; }

        public Event Event { get; set; }
    }
}
