using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.ViewModels
{
    public class EventEditViewModel
    {
        public int EventId { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
