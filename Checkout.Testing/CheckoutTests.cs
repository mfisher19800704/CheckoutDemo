
using Checkout.Core.Classes;
using Checkout.Core.Interfaces;
using Checkout.Core.Services;

namespace Checkout.Testing
{
    [TestClass]
    public class CheckoutTests
    {
        private List<IProduct> products = new List<IProduct>();
        private List<IDiscount> discounts = new List<IDiscount>();

        private void SetupProductList()
        {
            products.Add(new Product { ProductName = 'A', Price = 50 });
            products.Add(new Product { ProductName = 'B', Price = 30 });
            products.Add(new Product { ProductName = 'C', Price = 20 });
            products.Add(new Product { ProductName = 'D', Price = 15 });
        }

        private void SetupDiscountList() { 
            discounts.Add(new Discount { ProductName = 'A', Quantity = 3, DiscountValue = 20 });
            discounts.Add(new Discount { ProductName = 'B', Quantity = 2, DiscountValue = 15 });
        }

        [TestMethod]
        public void ScanThreeAItems()
        {
            //arrange 
            SetupProductList();
            SetupDiscountList();

            //act
            var checkout = new Checkout.Core.Services.Checkout(products, discounts);
            checkout.Scan("AAA");
            var result = checkout.GetTotalPrice();


            //assert 
            Assert.IsTrue(result == 130);
        }

        [TestMethod]
        public void ScanTwoBItems()
        {
            //arrange 
            SetupProductList();
            SetupDiscountList();

            //act
            var checkout = new Checkout.Core.Services.Checkout(products, discounts);
            checkout.Scan("BB");
            var result = checkout.GetTotalPrice();


            //assert 
            Assert.IsTrue(result == 45);
        }
    }
}