using System;
using System.Collections.Generic;

namespace MVCPlannerFinal.Models
{
    public class Organizer
    {
        public int OrganizerID { get; set; }
        public string OrganizationName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // Navigation property for OrganizedEvents
        public virtual List<Event>? OrganizedEvents { get; set; } = null!;
    }
}
