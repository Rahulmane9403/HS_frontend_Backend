using System;
using System.Collections.Generic;

namespace HomeServiceApp.Models
{
    public partial class Worker
    {
        public Worker()
        {
            Bookings = new HashSet<Booking>();
            Supports = new HashSet<Support>();
            SystemAdministrations = new HashSet<SystemAdministration>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public byte[] Photo { get; set; } = null!;
        public string Experience { get; set; } = null!;
        public string Skills { get; set; } = null!;
        public decimal Ratings { get; set; }
        public string Languages { get; set; } = null!;
        public string Availability { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public byte[] IdentityProof { get; set; } = null!;
        public string Gender { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Support> Supports { get; set; }
        public virtual ICollection<SystemAdministration> SystemAdministrations { get; set; }
    }
}
