using System;
using System.Collections.Generic;

namespace MVCPlannerFinal.Models
{
    public class Visitor
    {
        public int VisitorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PasswordHash { get; set; }

        // Navigation property for Payments
        public virtual List<Payment>? Payments { get; set; } = null!;
    }
}
