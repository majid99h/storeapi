using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModel
{
    public class CartDetailVm
    {
        public string CartId { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal Count { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductImage { get; set; }
        public string Category { get; set; }
    }
}
