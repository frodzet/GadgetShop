
using System;
using System.Collections.Generic;
using System.IO;
using WorldWideGadgetShop.Core.IServices;
using WorldWideGadgetShop.Core.Models;
using WorldWideGadgetShop.Domain.IRepositories;

namespace WorldWideGadgetShop.Domain.Services
{
    public class ProductService : IProductService
    {
        
        private readonly IProductRepository _productRepo;
        
        public ProductService(IProductRepository  productRepo)
        {
            _productRepo = productRepo;
        }

        public Product CreateProduct(Product product)
        {
            if (product.Name == null)
                throw new InvalidDataException("Product needs a Name");
            if (product.Type == null)
                throw new InvalidDataException("Product needs a Type");
            if (Math.Abs(product.Price) < 1)
                throw new InvalidDataException("Product Price needs to be more than 1");
            if (product.Description == null)
                throw new InvalidDataException("Product needs a description");
            var p = _productRepo.CreateProduct(product);
            return p;
        }
        
        public Product GetProductById(int id)
        {
            var p = _productRepo.GetProductById(id);
            return p;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepo.GetAllProducts();
        }

        public Product UpdateProduct(Product product)
        {
            var p = _productRepo.UpdateProduct(product);
            return p;
        }

        public Product DeleteProductById(int id)
        {
            var p = _productRepo.DeleteProductById(id);
            return p;
        }


    }
}