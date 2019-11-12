using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string Username { get; set; }
        public decimal? OrderTotal { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual User UsernameNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
