using System;
using System.ComponentModel.DataAnnotations;

namespace MVCPlannerFinal.Models
{
    public class Ticket
    {
        [Key]
        public int TicketTypeID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        // Foreign key for Event
        public int EventID { get; set; }
        public virtual Event? Event { get; set; } = null!;
    }
}
