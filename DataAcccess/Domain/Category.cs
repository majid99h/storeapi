using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public string CategoryName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
