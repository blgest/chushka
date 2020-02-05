using System;
using System.Collections.Generic;
using System.Text;

namespace Chushka.ViewModels.Models
{
    public class OrderViewModel
    {
        public string OrderId { get; set; }

        public string Customer { get; set; }

        public string Product { get; set; }

        public DateTime OrderedOn { get; set; }
    }
}
