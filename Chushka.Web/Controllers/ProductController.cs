using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chushka.Data;
using Chushka.Data.Models;
using Chushka.Services.Contracts;
using Chushka.ViewModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chushka.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ChushkaDbContext context;

        private readonly IProductService productService;

        public ProductController(ChushkaDbContext context, IProductService productService)
        {
            this.context = context;
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (this.User.IsInRole("Admin"))
            {
                var createProductViewModel = new CreateProductViewModel();

                return this.View(createProductViewModel);
            }
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel createProductViewModel)
        {
            this.productService.Create(
                createProductViewModel.Name,
                createProductViewModel.Price,
                createProductViewModel.Description,
                createProductViewModel.Type);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var curr = this.productService.Details(id);

                var detailsViewModel = new DetailsViewModel()
                {
                    Id = id,
                    Name = curr.Name,
                    Price = curr.Price,
                    Description = curr.Description,
                    Type = curr.Type
                };

                return this.View(detailsViewModel);
            }
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (this.User.IsInRole("Admin"))
            {
                var product = productService.Details(id);

                var editProductViewModel = new EditProductViewModel()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    Type = product.Type
                };
                return this.View(editProductViewModel);
            }
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel editProductViewModel, string id)
        {
            if (this.User.IsInRole("Admin"))
            {
                this.productService.Edit(
                    id,
                    editProductViewModel.Name,
                    editProductViewModel.Price,
                    editProductViewModel.Description,
                    editProductViewModel.Type
                    );
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (this.User.IsInRole("Admin"))
            {
                var product = productService.Details(id);

                var deleteProductViewModel = new DeleteProductViewModel()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    Type = product.Type
                };
                return this.View(deleteProductViewModel);
            }
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteProductViewModel deleteProductViewModel, string id)
        {
            if (this.User.IsInRole("Admin"))
            {
                this.productService.Delete(id);
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }
    }
}