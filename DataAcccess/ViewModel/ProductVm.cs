using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModel
{
    public class ProductVm
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductImage { get; set; }
        public string Category { get; set; }

        public Product MapTo(ProductVm vm)
        {
            Product product = new Product();
            product.ProductId = vm.ProductId;
            product.ProductName = vm.ProductName;
            product.ProductImage = vm.ProductImage;
            product.Category = vm.Category;
            product.Price = vm.Price;
            return product;
        }
    }
}
