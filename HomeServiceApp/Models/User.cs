using System;
using System.Collections.Generic;

namespace HomeServiceApp.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Supports = new HashSet<Support>();
            SystemAdministrations = new HashSet<SystemAdministration>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Preferences { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Support> Supports { get; set; }
        public virtual ICollection<SystemAdministration> SystemAdministrations { get; set; }
    }
}
