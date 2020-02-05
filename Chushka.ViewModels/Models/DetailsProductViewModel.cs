using Chushka.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chushka.ViewModels.Models
{
    public class DetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ProductType Type { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
