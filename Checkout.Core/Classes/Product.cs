using Checkout.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Core.Classes
{
    public  class Product : IProduct
    {
        public char ProductName { get; set; }
        public int Price { get; set;}
    }
}
