using Chushka.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chushka.Services.Contracts
{
    public interface IOrderService
    {
        void AddOrder(string productId, string clientId, DateTime orderedOn);
    }
}
