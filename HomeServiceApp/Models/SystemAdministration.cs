using System;
using System.Collections.Generic;

namespace HomeServiceApp.Models
{
    public partial class SystemAdministration
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? WorkerId { get; set; }
        public string ActionType { get; set; } = null!;
        public string ActionDescription { get; set; } = null!;
        public DateTime ActionTime { get; set; }

        public virtual User? User { get; set; }
        public virtual Worker? Worker { get; set; }
    }
}
