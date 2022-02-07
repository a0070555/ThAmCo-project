using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.Models
{
    public class MenuFoodItem
    {

        public MenuFoodItem()
        {
        }

        public int MenuId { get; set; }

        public int FoodItemId { get; set; }

        public FoodItem FoodItem { get; set; }

        public Menu Menu { get; set; }
    }
}
