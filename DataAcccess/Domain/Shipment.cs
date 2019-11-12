using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public partial class Shipment
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime? ShipmentDate { get; set; }
        [NotMapped]
        public string CartId { get; set; }
        public virtual User UserNameNavigation { get; set; }
    }
}
