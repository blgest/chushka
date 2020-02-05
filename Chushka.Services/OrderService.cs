using Chushka.Data;
using Chushka.Data.Models;
using Chushka.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chushka.Services
{
    public class OrderService : IOrderService
    {
        private ChushkaDbContext chushkaDbContext;

        public OrderService(ChushkaDbContext chushkaDbContext)
        {
            this.chushkaDbContext = chushkaDbContext;
        }

        public void AddOrder(string productId, string username, DateTime orderedOn)
        {
            var product = this.chushkaDbContext.Products.FirstOrDefault(x => x.Id == productId);
          
            var client = this.chushkaDbContext.Users.FirstOrDefault(x => x.UserName == username);
          
            var order = new Order()
            {
                Id = Guid.NewGuid().ToString(),
                ProductId = productId,
                Product = product,
                ClientId = client.Id,
                Client = client,
                OrderedOn = orderedOn
            };

            
            product.Orders.Add(order);

            this.chushkaDbContext.Orders.Add(order);

            this.chushkaDbContext.SaveChanges();
        }
    }
}
