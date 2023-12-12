using System;
using System.Collections.Generic;

namespace ChuQuangHuy_211204440.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductId { get; set; } = null!;
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
