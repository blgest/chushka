using Chushka.Data.Models;
using System.Collections.Generic;

namespace Chuska.View.Models
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public ICollection<ProductType> Type { get; set; }
    }
}
