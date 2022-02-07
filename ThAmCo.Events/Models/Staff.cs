using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class Staff
    {

        public Staff()
        {
            FirstAider = false;
        }

        public int StaffId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Aider")]
        public bool FirstAider { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
