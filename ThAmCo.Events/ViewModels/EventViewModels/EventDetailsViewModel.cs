using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.ViewModels.EventViewModels
{
    public class EventDetailsViewModel
    {
        public int EventId { get; set; }

        [Required]
        public string Title { get; set; }

        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [Display(Name = "Event Type")]
        public string EventType { get; set; }
    }
}
