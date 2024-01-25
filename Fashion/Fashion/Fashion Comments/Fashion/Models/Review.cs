﻿using System;
using System.Collections.Generic;

namespace Fashion.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Polzovatel User { get; set; } = null!;
    }
}
