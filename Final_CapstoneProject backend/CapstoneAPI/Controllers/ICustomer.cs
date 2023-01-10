using CapstoneAPI.Models;

namespace CapstoneAPI.Controllers
{
    public interface ICustomer
    {
        bool AddOrder(Order o);

        List<Order> ShowAllOrders(string EmailId);

        List<Product> ShowAllProducts();

        List<Product> ShowProductByCategory(string ProdType);

        List<Product> ShowProductByName(string ProdName);

        bool AddShippingAddress(Address a);

        bool AddToCart(Cart c);

        bool AddToWishList(Wishlist w);

        bool GiveProductRating(int ProdId, float rating);

        string ShowOrderStatus(int OrderId);

        bool CancelOrReturnOrder(int OrderId, string NewStatus);

        bool GetReturnStatus(int OrderId);

        bool DeleteItemFromCart(int CartId);

        bool DeleteItemFromWishlist(int WishlistId);

        List<Cart> ShowAllCart(string EmailId);

        List<Wishlist> ShowAllWishlist(string EmailId);

        bool EmptyCart(string EmailId);
        bool EmptyWishlist(string EmailId);

        Order ShowLatestOrder();

        List<Address> ShowAllShippingAddress(string EmailId);

        bool CheckPinCode(int Pincode, string EmailId);

        Product GetProductById(int productId);


    }
}
