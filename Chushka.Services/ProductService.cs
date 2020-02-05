using Chushka.Data;
using Chushka.Data.Models;
using Chushka.Services.Contracts;
using System;
using System.Linq;

namespace Chushka.Services
{
    public class ProductService : IProductService
    {
        private ChushkaDbContext chushkaDbContext;

        public ProductService(ChushkaDbContext chushkaDbContext)
        {
            this.chushkaDbContext = chushkaDbContext;
        }

        public void Create(string name, decimal price, string description, ProductType type)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Price = price,
                Description = description,
                Type = type
            };

            chushkaDbContext.Products.Add(product);
            chushkaDbContext.SaveChanges();
        }

        public Product Details(string id)
        {
            return this.chushkaDbContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Edit(string id, string name, decimal price, string description, ProductType type)
        {
            var product = this.chushkaDbContext.Products.FirstOrDefault(x => x.Id == id);

            product.Name = name;
            product.Price = price;
            product.Description = description;
            product.Type = type;
            
            chushkaDbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var product = this.chushkaDbContext.Products.FirstOrDefault(x => x.Id == id);

            product.IsDeleted = true;

            chushkaDbContext.SaveChanges();
        }
    }
}
