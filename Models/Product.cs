using System;
using System.Collections.Generic;

namespace ChuQuangHuy_211204440.Models
{
    public partial class Product
    {
        public Product()
        {
            Comments = new HashSet<Comment>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double UnitPrice { get; set; }
        public string? Image { get; set; }
        public bool Available { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public int ProviderId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Provider Provider { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
