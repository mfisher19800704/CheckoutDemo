using Checkout.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Core.Classes
{
    public class Discount : IDiscount
    {
        public char  ProductName { get; set; }
        public int Quantity { get; set; }

        public int DiscountValue { get; set;  }
    }
}
