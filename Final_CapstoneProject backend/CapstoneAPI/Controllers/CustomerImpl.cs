using CapstoneAPI.Models;

namespace CapstoneAPI.Controllers
{
    public class CustomerImpl : ICustomer
    {
        readonly CapstoneAPIDbContext db;
        public CustomerImpl(CapstoneAPIDbContext db)
        {
            this.db = db;
        }
        public bool AddOrder(Order o)
        {
            try
            {
                var olddata = db.Product.Where(c => c.ProductId == o.ProductId).FirstOrDefault();
                if (olddata.ProductQuantity < o.QuantityPurchased)
                {
                    return false;
                }
                else
                {
                    olddata.ProductQuantity = olddata.ProductQuantity - o.QuantityPurchased;
                    o.TotalPrice = (olddata.ProductPrice * o.QuantityPurchased) + o.ShippingCost;
                    o.ReturnStatus = false;
                    o.DeliveryStatus = "On The Way";
                    o.OrderDate = DateTime.Now;
                    db.Order.Add(o);
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public bool AddShippingAddress(Address a)
        {
            try
            {
                db.Address.Add(a);
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public bool AddToCart(Cart c)
        {
            try
            {
                db.Cart.Add(c);
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public bool AddToWishList(Wishlist w)
        {
            try
            {
                db.Wishlist.Add(w);
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public bool CancelOrReturnOrder(int OrderId, string NewStatus)
        {
            try
            {
                var olddata = db.Order.Where(c => c.OrderId == OrderId).FirstOrDefault();
                olddata.DeliveryStatus = NewStatus;
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;

        }

        public bool CheckPinCode(int Pincode, string EmailId)
        {
            var oldata = db.DeliveryPincode.Where(x => x.EmailId == EmailId && x.PinCode == Pincode).FirstOrDefault();
            if (oldata == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool DeleteItemFromCart(int CartId)
        {
            try
            {
                var data = db.Cart.Where(x => x.CartId == CartId).FirstOrDefault();
                if (data == null)
                    return false;
                else
                {
                    db.Cart.Remove(data);
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public bool DeleteItemFromWishlist(int WishlistId)
        {
            try
            {
                var data = db.Wishlist.Where(x => x.WishListId == WishlistId).FirstOrDefault();
                if (data == null)
                    return false;
                else
                {
                    db.Wishlist.Remove(data);
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public bool EmptyCart(string EmailId)
        {
            try
            {
                var removecart = db.Cart.Where(c => c.EmailId == EmailId).ToList();
                db.Cart.RemoveRange(removecart);
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public bool EmptyWishlist(string EmailId)
        {
            try
            {
                var removewishlist = db.Wishlist.Where(c => c.EmailId == EmailId).ToList();
                db.Wishlist.RemoveRange(removewishlist);
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public bool GetReturnStatus(int OrderId)
        {
            try
            {
                var olddata = db.Order.Where(c => c.OrderId == OrderId).FirstOrDefault();
                return olddata.ReturnStatus;

            }
            catch
            {
                return false;
            }
            return false;
        }

        public bool GiveProductRating(int ProdId, float rating)
        {
            try
            {
                var prod = db.Product.Where(c => c.ProductId == ProdId).FirstOrDefault();
                var avgrate = ((prod.Rating * prod.NoOfRatings) + rating) / (prod.NoOfRatings + 1);
                prod.Rating = avgrate;
                prod.NoOfRatings = prod.NoOfRatings + 1;
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public List<Cart> ShowAllCart(string EmailId)
        {
            return db.Cart.Where(x => x.EmailId == EmailId).ToList();
        }

        public List<Order> ShowAllOrders(string EmailId)
        {
            return db.Order.Where(x => x.EmailId == EmailId).ToList();
        }

        public List<Product> ShowAllProducts()
        {
            return db.Product.ToList();
        }

        public List<Address> ShowAllShippingAddress(string EmailId)
        {
            return db.Address.Where(x => x.EmailId == EmailId).ToList();
        }

        public List<Wishlist> ShowAllWishlist(string EmailId)
        {
            return db.Wishlist.Where(x => x.EmailId == EmailId).ToList();
        }

        public Order ShowLatestOrder()
        {
            var max = db.Order.Max(x => x.OrderId);
            var data = db.Order.Where(x => x.OrderId == max).FirstOrDefault();
            return data;
        }

        public string ShowOrderStatus(int OrderId)
        {
            var olddata = db.Order.Where(x => x.OrderId == OrderId).FirstOrDefault();
            return olddata.DeliveryStatus;
        }

        public List<Product> ShowProductByCategory(string ProdType)
        {
            return db.Product.Where(x => x.ProductType == ProdType).ToList();
        }

        public List<Product> ShowProductByName(string ProdName)
        {
            return db.Product.Where(x => x.ProductName == ProdName).ToList();
        }

        public Product GetProductById(int productId)
        {
            return db.Product.Where(x => x.ProductId == productId).FirstOrDefault();
        }

    }


}

