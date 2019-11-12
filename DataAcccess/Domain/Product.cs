using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public partial class Product
    {
        public Product()
        {
            CartDetail = new HashSet<CartDetail>();
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductImage { get; set; }
        public string Category { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual ICollection<CartDetail> CartDetail { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
