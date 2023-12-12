using System;
using System.Collections.Generic;

namespace ChuQuangHuy_211204440.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? NameVn { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
