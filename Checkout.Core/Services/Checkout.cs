using Checkout.Core.Classes;
using Checkout.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Core.Services
{
    public class Checkout : ICheckout
    {
        private readonly IList<IProduct> _products;
        private readonly IList<IDiscount> _discounts;
        private char[] scannedItems;

        public Checkout( List<IProduct> products, List<IDiscount> discounts) 
        {
            _products = products;
            _discounts = discounts;            
        }

        public int GetTotalPrice()
        {
            int TotalPrice = scannedItems.Sum(x => GetPrice(x));
            int TotalDiscount = _discounts.Sum(x => GetDiscount(x, scannedItems));

            return TotalPrice - TotalDiscount;
        }


        private int GetDiscount(IDiscount discount, char[] cart)
        {
            int itemCount = cart.Count(item => item == discount.ProductName);
            return (itemCount / discount.Quantity) * discount.DiscountValue;
        }


        private int GetPrice(char ProductName)
        {
            return _products.Single(x => x.ProductName == ProductName).Price;
        }

        public void Scan(string item)
        {
            scannedItems = item.ToCharArray();
        }
    }
}
