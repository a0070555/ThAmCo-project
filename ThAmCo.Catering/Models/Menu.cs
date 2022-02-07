using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.Models
{
    public class Menu
    {
        public Menu()
        {
        }

        public int MenuId { get; set; }

        [Required]
        public string MenuName { get; set; }
    }
}
