using Microsoft.AspNetCore.Mvc;
using Checkout.Core.Interfaces;
using Checkout.Core.Classes;

namespace Checkout.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
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

        private void SetupDiscountList()
        {
            discounts.Add(new Discount { ProductName = 'A', Quantity = 3, DiscountValue = 20 });
            discounts.Add(new Discount { ProductName = 'B', Quantity = 2, DiscountValue = 15 });
        }

        public CheckoutController()
        {
            //these should be in a repo and injected in 
            SetupDiscountList();
            SetupProductList();
           
        }

        [HttpGet]
        public int Get( string scannedproduct )
        {
            var checkout = new Checkout.Core.Services.Checkout(products, discounts); ;

            checkout.Scan(scannedproduct);
            return checkout.GetTotalPrice();
        }

    }
}
