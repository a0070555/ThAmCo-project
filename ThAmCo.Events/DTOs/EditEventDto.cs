using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.DTOs
{
    public class EditEventDto
    {
        public int EventId { get; set; }

        [Required]
        public string Title { get; set; }

    }
}
