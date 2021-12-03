using System.Collections.Generic;
using WorldWideGadgetShop.Core.Models;

namespace WorldWideGadgetShop.Core.IServices
{
    public interface IProductService
    {
        // Create
        Product CreateProduct(Product product);
        
        // Read
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        
        // Update
        Product UpdateProduct(Product product);
        
        // Delete
        Product DeleteProductById(int id);
    }
}