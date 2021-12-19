using System;
using System.IO;
using Moq;
using WorldWideGadgetShop.Core.IServices;
using WorldWideGadgetShop.Core.Models;
using WorldWideGadgetShop.Domain.IRepositories;
using WorldWideGadgetShop.Domain.Services;
using Xunit;

namespace ProductServiceTest2
{
    public class ProductServiceTest
    {

             
        public void Dispose()
        {
            //Dispose Stuff we dont need anymore
        }
        
        [Fact]
        public void CreateProductWithoutName()
        {
            var productRepo = new Mock<IProductRepository>();
            IProductService service = 
                new ProductService(productRepo.Object);
            var product = new Product()
            {
                Id = 1,
              //  Name = "Hollaballoon----------------",
                Type = "balloon animal",
                ImageURL = "the_bad_stuff.christmas",
                Price = 200,
                Amount = 20,
                Description = "test"
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateProduct(product));
            
            Assert.Equal("Product needs a Name", ex.Message);
        }
        
        
        [Fact]
        public void CreateProductWithoutCategory()
        {
            var productRepo = new Mock<IProductRepository>();
            IProductService service = 
                new ProductService(productRepo.Object);
            var product = new Product()
            {
                Id = 2,
                Name = "Holla123123balloon",
              //Category = "balloo123n animal----------------",
                ImageURL = "the_bad_123123stuff.christmas",
                Price = 200,
                Amount = 20,
                Description = "test"
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateProduct(product));
            
            Assert.Equal("Product needs a Type", ex.Message);
        }
        
        [Fact]
        public void CreateProductWithoutDescription()
        {
            var productRepo = new Mock<IProductRepository>();
            IProductService service = 
                new ProductService(productRepo.Object);
            var product = new Product()
            {
                Id = 2,
                Name = "testtestetsetsetest",
                Type = "basdfasdfasdf",
                ImageURL = "the_bad_123123stuff.christmas",
                Price = 200,
                Amount = 20,
                //Description = "test"
            };
            Exception ex = Assert.Throws<InvalidDataException>(() =>
                service.CreateProduct(product));
            
            Assert.Equal("Product needs a description", ex.Message);
        }
        

        
        [Fact]
        public void CreateProductShouldCallProductRepoCreateProductOnce()
        {
            var productRepo = new Mock<IProductRepository>();
            IProductService service =
                new ProductService(productRepo.Object);
            var product = new Product()
            {
                Id = 1,
                Name = "Hollaballoon",
                Type = "balloon animal",
                ImageURL = "the_bad_stuff.christmas",
                Price = 200,
                Amount = 20,
                Description = "test"
            };

            service.CreateProduct(product);
            productRepo.Verify(x => x.CreateProduct(It.IsAny<Product>()), Times.Once);
        }

    }
}