using System;
using System.Collections.Generic;

namespace MVCPlannerFinal.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }

        // Foreign key for Visitor
        public int VisitorID { get; set; }
        public virtual Visitor? Visitor { get; set; } = null;

        // Foreign key for Event
        public int EventID { get; set; }
        public virtual Event? Event { get; set; } = null!;

        public int PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
