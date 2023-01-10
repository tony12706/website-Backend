using CapstoneAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAPI.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    [EnableCors(PolicyName = "CapstoneProject")]
    public class CustomerController : ControllerBase
    {
        readonly CapstoneAPIDbContext db;
        readonly ICustomer cust;

        public CustomerController(CapstoneAPIDbContext db, ICustomer cust)
        {
            this.db = db;
            this.cust = cust;
        }
        [HttpPost]
        [Route("/api/Customer/AddOrder")]
        public bool AddOrder([FromBody] Order o)
        {
            return cust.AddOrder(o);
        }



        [HttpGet]
        [Route("/api/Customer/ShowAllOrders/{EmailId}")]
        public List<Order> ShowAllOrders(string EmailId)
        {
            return cust.ShowAllOrders(EmailId);
        }



        [HttpGet]
        [Route("/api/Customer/ShowAllProducts")]
        public List<Product> ShowAllProducts()
        {
            return cust.ShowAllProducts();
        }



        [HttpGet]
        [Route("/api/Customer/ShowProductByCategory/{ProdType}")]
        public List<Product> ShowProductByCategory(string ProdType)
        {
            return cust.ShowProductByCategory(ProdType);
        }



        [HttpGet]
        [Route("/api/Customer/ShowProductByName/{ProdName}")]
        public List<Product> ShowProductByName(string ProdName)
        {
            return cust.ShowProductByName(ProdName);
        }



        [HttpPost]
        [Route("/api/Customer/AddShippingAddress")]
        public bool AddShippingAddress([FromBody] Address a)
        {
            return cust.AddShippingAddress(a);
        }



        [HttpPost]
        [Route("/api/Customer/AddToCart")]
        public bool AddToCart([FromBody] Cart c)
        {
            return cust.AddToCart(c);
        }



        [HttpPost]
        [Route("/api/Customer/AddToWishList")]
        public bool AddToWishList([FromBody] Wishlist w)
        {
            return cust.AddToWishList(w);
        }



        [HttpPut]
        [Route("/api/Customer/GiveProductRating/{ProdId}/{rating}")]
        public bool GiveProductRating(int ProdId, float rating)
        {
            return cust.GiveProductRating(ProdId, rating);
        }



        [HttpGet]
        [Route("/api/Customer/ShowOrderStatus/{OrderId}")]
        public string ShowOrderStatus(int OrderId)
        {
            return cust.ShowOrderStatus(OrderId);
        }



        [HttpPut]
        [Route("/api/Customer/CancelOrReturnOrder/{OrderId}/{NewStatus}")]
        public bool CancelOrReturnOrder(int OrderId, string NewStatus)
        {
            return cust.CancelOrReturnOrder(OrderId, NewStatus);
        }



        [HttpGet]
        [Route("/api/Customer/GetReturnStatus/{OrderId}")]
        public bool GetReturnStatus(int OrderId)
        {
            return cust.GetReturnStatus(OrderId);
        }



        [HttpDelete]
        [Route("/api/Customer/DeleteItemFromCart/{CartId}")]
        public bool DeleteItemFromCart(int CartId)
        {
            return cust.DeleteItemFromCart(CartId);
        }



        [HttpDelete]
        [Route("/api/Customer/DeleteItemFromWishlist/{WishlistId}")]
        public bool DeleteItemFromWishlist(int WishlistId)
        {
            return cust.DeleteItemFromWishlist(WishlistId);
        }



        [HttpGet]
        [Route("/api/Customer/ShowAllCart/{EmailId}")]
        public List<Cart> ShowAllCart(string EmailId)
        {
            return cust.ShowAllCart(EmailId);
        }



        [HttpGet]
        [Route("/api/Customer/ShowAllWishlist/{EmailId}")]
        public List<Wishlist> ShowAllWishlist(string EmailId)
        {
            return cust.ShowAllWishlist(EmailId);
        }



        [HttpDelete]
        [Route("/api/Customer/EmptyCart/{EmailId}")]
        public bool EmptyCart(string EmailId)
        {
            return cust.EmptyCart(EmailId);
        }



        [HttpDelete]
        [Route("/api/Customer/EmptyWishlist/{EmailId}")]
        public bool EmptyWishlist(string EmailId)
        {
            return cust.EmptyWishlist(EmailId);
        }



        [HttpGet]
        [Route("/api/Customer/ShowLatestOrder")]
        public Order ShowLatestOrder()
        {
            return cust.ShowLatestOrder();
        }



        [HttpGet]
        [Route("/api/Customer/ShowAllShippingAddress/{EmailId}")]
        public List<Address> ShowAllShippingAddress(string EmailId)
        {
            return cust.ShowAllShippingAddress(EmailId);
        }



        [HttpGet]
        [Route("/api/Customer/CheckPinCode/{Pincode}/{EmailId}")]
        public bool CheckPinCode(int Pincode, string EmailId)
        {
            return cust.CheckPinCode(Pincode, EmailId);
        }

        [HttpGet]
        [Route("/api/Customer/GetProductById/{productId}")]
        public Product GetProductById(int productId)
        {
            return cust.GetProductById(productId);
        }
    }
}
