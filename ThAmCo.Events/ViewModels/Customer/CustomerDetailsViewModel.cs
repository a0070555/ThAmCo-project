using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.ViewModels
{
    public class CustomerDetailsViewModel
    {
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public bool Attendance { get; set; }

        public IEnumerable<Event> Events { get; set; }

        public IEnumerable<Models.GuestBooking> GuestBookings { get; set; }
    }
}
