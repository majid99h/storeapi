using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public partial class CartDetail
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string CartId { get; set; }
        public decimal? Quantity { get; set; }
        [NotMapped]
        public int Count { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
