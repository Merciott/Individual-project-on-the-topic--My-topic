using System;
using System.Collections.Generic;

namespace Fashion.Models
{
    public partial class Polzovatel
    {
        public Polzovatel()
        {
            Reviews = new HashSet<Review>();
            Zakazis = new HashSet<Zakazi>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Zakazi> Zakazis { get; set; }
    }
}
