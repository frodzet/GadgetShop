
using System.Collections.Generic;
using WorldWideGadgetShop.Core.Models;

namespace WorldWideGadgetShop.Domain.IRepositories
{
    public interface IProductRepository
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