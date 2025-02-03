using System;
using System.Collections.Generic;

namespace HomeServiceApp.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime Time { get; set; }

        public virtual Booking Booking { get; set; } = null!;
    }
}
