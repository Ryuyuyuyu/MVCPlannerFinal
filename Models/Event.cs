using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCPlannerFinal.Models
{
    public class Event
    {
        public int EventID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Price { get; set; }
        public int Participants { get; set; }

        // Foreign key for Organizer
        public int OrganizerID { get; set; }
        public virtual Organizer? Organizer { get; set; } = null;

        // Navigation property for Tickets
        public virtual List<Ticket>? Tickets { get; set; } = null!;
        //public virtual ICollection<car>? Cars {get; set; }

        public void ReduceParticipants(int count)
        {
            if (Participants >= count)
            {
                Participants -= count;
                Console.WriteLine($"Reduced {count} participants. Remaining participants: {Participants}");
            }
            else
            {
                Console.WriteLine("Desired count exceeds current participants. Cannot reduce.");
            }
        }
    }
}
