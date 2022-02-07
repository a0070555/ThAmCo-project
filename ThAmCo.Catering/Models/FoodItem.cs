using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.Models
{
    public class FoodItem
    {

        public FoodItem()
        {
        }

        public int FoodItemId { get; set; }

        [Required]
        public string Description { get; set; }

        public float UnitPrice { get; set; }

    }
}
