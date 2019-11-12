using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public partial class Cart
    {
        public Cart()
        {
            CartDetail = new HashSet<CartDetail>();
        }

        public string CartId { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<CartDetail> CartDetail { get; set; }
    }
}
