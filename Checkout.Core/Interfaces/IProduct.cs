using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Core.Interfaces
{
    public interface IProduct
    {
        public char ProductName { get; set; }
        public int Price { get;set; }
    }
}
