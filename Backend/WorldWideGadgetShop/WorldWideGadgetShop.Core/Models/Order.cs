using System.Collections.Generic;

namespace WorldWideGadgetShop.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public List<Product> ProductsInCart { get; set; }
    }
}