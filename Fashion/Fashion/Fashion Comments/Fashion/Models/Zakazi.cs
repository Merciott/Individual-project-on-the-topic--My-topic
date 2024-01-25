using System;
using System.Collections.Generic;

namespace Fashion.Models
{
    public partial class Zakazi
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public TimeSpan OrderTime { get; set; }
        public int? ProductId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Polzovatel User { get; set; } = null!;
    }
}
