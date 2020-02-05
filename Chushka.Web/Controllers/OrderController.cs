using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chushka.Data;
using Chushka.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Chushka.ViewModels.Models;
using Chushka.Services.Contracts;

namespace Chushka.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly ChushkaDbContext chushkaDbContext;

        private readonly IOrderService orderService;

        public OrderController(ChushkaDbContext chushkaDbContext, IOrderService orderService)
        {
            this.chushkaDbContext = chushkaDbContext;
            this.orderService = orderService;
        }

        
        public async Task<IActionResult> Create(string id)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                orderService.AddOrder(id, this.User.Identity.Name, DateTime.UtcNow);
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var orderViewModels = new List<OrderViewModel>();

                foreach (var order in this.chushkaDbContext.Orders)
                {
                    var product = this.chushkaDbContext.Products.FirstOrDefault(x => x.Id == order.ProductId);

                    var client = this.chushkaDbContext.Users.FirstOrDefault(x => x.Id == order.ClientId);

                    var orderViewModel = new OrderViewModel()
                    {
                        OrderId = order.Id,
                        Customer = client.UserName,
                        Product = product.Name,
                        OrderedOn = order.OrderedOn
                    };

                    orderViewModels.Add(orderViewModel);
                }

                return this.View("All", orderViewModels);
            }
            return this.View();
        }
    }
}