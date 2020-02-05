using Chushka.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chushka.Services.Contracts
{
    public interface IProductService
    {
        void Create(string name, decimal price, string description, ProductType type);

        Product Details(string id);

        void Edit(string id, string name, decimal price, string description, ProductType type);

        void Delete(string id);
    }
}
