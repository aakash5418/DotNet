//Todo: Karthick Code Review

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Store
{
    public class ProductStoreInfo
    {
        public long ProductId { get; set; }

        public string ProductName { get; set; }


        public decimal UnitPrice { get; set; }

        public decimal UnitDiscount { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
