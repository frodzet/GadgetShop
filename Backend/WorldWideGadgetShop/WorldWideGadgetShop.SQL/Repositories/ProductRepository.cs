using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WorldWideGadgetShop.Core.Models;
using WorldWideGadgetShop.Domain.IRepositories;

namespace WorldWideGadgetShop.SQL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DBContext _ctx;

        public ProductRepository(DBContext ctx)
        {
            _ctx = ctx;
        }

        public Product CreateProduct(Product product)
        {
            _ctx.Attach(product).State = EntityState.Added;
            _ctx.SaveChanges();
            return product;
        }
        
        public Product GetProductById(int id)
        {
            var p = _ctx.Products.FirstOrDefault(p => p.Id == id);
            return p;
        }

        public Product UpdateProduct(Product product)
        {
            _ctx.Products.Attach(product).State = EntityState.Modified;
            _ctx.SaveChanges();
            return product;
        }

        public List<Product> GetAllProducts()
        {
            return _ctx.Products.ToList();
        }

        public Product DeleteProductById(int id)
        {
            var p = _ctx.Products.FirstOrDefault(p => p.Id == id);
            _ctx.Products.Attach(p).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return p;
        }
    }
}