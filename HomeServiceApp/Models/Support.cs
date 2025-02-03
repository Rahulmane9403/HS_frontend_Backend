using System;
using System.Collections.Generic;

namespace HomeServiceApp.Models
{
    public partial class Support
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookingId { get; set; }
        public int WorkerId { get; set; }
        public string IssueDescription { get; set; } = null!;
        public string Resolution { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual Booking Booking { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual Worker Worker { get; set; } = null!;
    }
}
