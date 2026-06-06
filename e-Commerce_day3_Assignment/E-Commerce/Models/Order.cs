using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        

        public Order(int id,string product, decimal productPrice, int quantity)
        {
            Id= id;
            Product = product;
            ProductPrice = productPrice;
            Quantity = quantity;
        }

    }
}
