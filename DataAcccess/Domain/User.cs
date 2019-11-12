using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
            Shipment = new HashSet<Shipment>();
        }

        public string UserName { get; set; }
        public string Role { get; set; }
        public string CreateDate { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public string Token { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Shipment> Shipment { get; set; }
    }
}
