using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Security.Models
{
    public partial class Products
    {
        public int ProductRowId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Manufacturer { get; set; }
        public string Desicription { get; set; }
        public int Price { get; set; }
        public int CategoryRowId { get; set; }

        public virtual Categories CategoryRow { get; set; }
    }
}
