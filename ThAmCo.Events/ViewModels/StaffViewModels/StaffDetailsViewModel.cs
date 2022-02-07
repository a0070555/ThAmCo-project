using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.ViewModels.StaffViewModels
{
    public class StaffDetailsViewModel
    {
        public StaffDetailsViewModel()
        {
            FirstAider = false;
        }

        public int StaffId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Aider")]
        public bool FirstAider { get; set; }

        public IEnumerable<Event> Events { get; set; }

        public IEnumerable<Staffing> Staffing { get; set; }
    }
}
