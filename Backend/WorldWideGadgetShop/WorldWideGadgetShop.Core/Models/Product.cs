using System;

namespace WorldWideGadgetShop.Core.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public bool CanShow { get; set; }
    }
}