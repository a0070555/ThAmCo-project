using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class GuestBooking
    {
        public GuestBooking()
        {
            Attendance = false;
        }

        public int EventId { get; set; }

        public int CustomerId { get; set; }

        public bool Attendance { get; set; }

        public Customer Customer { get; set; }

        public Event Event { get; set; }
    }
}
