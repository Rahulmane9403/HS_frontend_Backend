using System;
using System.Collections.Generic;

namespace HomeServiceApp.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public decimal Rating { get; set; }
        public string Review { get; set; } = null!;
        public DateTime Time { get; set; }

        public virtual Booking Booking { get; set; } = null!;
    }
}
