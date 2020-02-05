using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Chushka.Web.Models;
using Microsoft.AspNetCore.Identity;
using Chushka.Data;
using Chushka.Data.Models;
using Chushka.Services.Contracts;
using Chushka.ViewModels.Models;
using AutoMapper;

namespace Chushka.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ChushkaDbContext context;

        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(ChushkaDbContext context, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            //await roleManager.CreateAsync(new IdentityRole("Admin"));
            //await roleManager.CreateAsync(new IdentityRole("User"));

            if (!this.User.Identity.IsAuthenticated)
            {
                return this.View();
            }

            var products = new List<ProductViewModel>();

            foreach (var product in this.context.Products)
            {
                if (product.IsDeleted == false)
                {
                    var productView = new ProductViewModel()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price
                    };

                    products.Add(productView);
                }
            }

            return this.View("Home", products);
        }
    }
}
