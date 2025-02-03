using System;
using System.Collections.Generic;

namespace HomeServiceApp.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Feedbacks = new HashSet<Feedback>();
            Payments = new HashSet<Payment>();
            Supports = new HashSet<Support>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkerId { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; } = null!;
        public string JobDetails { get; set; } = null!;
        public string Status { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Worker Worker { get; set; } = null!;
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Support> Supports { get; set; }
    }
}
