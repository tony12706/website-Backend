using CapstoneAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;

namespace CapstoneAPI.Controllers
{
    [Route("api/Seller")]
    [ApiController]
    [EnableCors(PolicyName = "CapstoneProject")]
    public class SellerController : ControllerBase
    {
        readonly CapstoneAPIDbContext db;
        readonly ISeller sell;
        public SellerController(CapstoneAPIDbContext db, ISeller sell)
        {
            this.db = db;
            this.sell = sell;
        }

        [HttpPost]
        [Route("/api/Seller/AddProduct")]
        public bool AddProduct([FromBody] Product p)
        {
            return sell.AddProduct(p);
        }

        [HttpDelete]
        [Route("/api/Seller/DeleteProduct/{ProductId}")]
        public bool DeleteProduct(int ProductId)
        {
            return sell.DeleteProduct(ProductId);
        }

        [HttpPut]
        [Route("/api/Seller/UpdateProduct/{ProductId}")]
        public bool UpdateProduct(int ProductId,[FromBody] Product p)
        {
            return sell.UpdateProduct(ProductId, p);
        }

        [HttpPost]
        [Route("/api/Seller/AddPinCode")]

        public bool AddPinCode([FromBody] DeliveryPincode pin)
        {
            return sell.AddPinCode(pin);
        }

        [HttpGet]
        [Route("/api/Seller/ShowAllProductsOfSeller/{EmailId}")]

        public List<Product> ShowAllProductsOfSeller(string EmailId)
        {
            return sell.ShowAllProductsOfSeller(EmailId);
        }

        [HttpGet]
        [Route("/api/Seller/ShowAllOrdersOfSeller/{SellerEmailId}")]
        public List<Order> ShowAllOrdersOfSeller(string SellerEmailId)
        {
            return sell.ShowAllOrdersOfSeller(SellerEmailId);
        }

        [HttpPut]
        [Route("/api/Seller/UpdateDeliveryStatus/{OrderId}/{delstatus}")]
        public bool UpdateDeliveryStatus(int OrderId, string delstatus)
        {
            return sell.UpdateDeliveryStatus(OrderId, delstatus);
        }

        [HttpPut]
        [Route("/api/Seller/UpdateReturnStatus/{OrderId}/{retstatus}")]

        public bool UpdateReturnStatus(int OrderId, bool retstatus)
        {
            return sell.UpdateReturnStatus(OrderId, retstatus);
        }

        [HttpGet]
        [Route("/api/Seller/ShowOrderById/{OrderId}")]

        public Order ShowOrderById(int OrderId)
        {
            return sell.ShowOrderById(OrderId);
        }
    }
}
