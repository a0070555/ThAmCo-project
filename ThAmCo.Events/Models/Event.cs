using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThAmCo.Venues.Data;

namespace ThAmCo.Events.Models
{
    public class Event
    {

        public Event()
        {
            IsDeleted = false;
        }

        public int EventId { get; set; }

        [Required]
        public string Title { get; set; }

        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [Required]
        [Display(Name = "Event Type")]
        public string EventType { get; set; }

        public bool IsDeleted { get; set; }

    }
}
