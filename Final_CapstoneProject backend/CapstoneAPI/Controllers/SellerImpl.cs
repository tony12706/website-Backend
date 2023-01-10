using CapstoneAPI.Models;

namespace CapstoneAPI.Controllers
{
    public class SellerImpl : ISeller
    {
        readonly CapstoneAPIDbContext db;
        public SellerImpl(CapstoneAPIDbContext db)
        {
            this.db = db;
        }

        public bool AddPinCode(DeliveryPincode pin)
        {
            try
            {
                db.DeliveryPincode.Add(pin);
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

        public bool AddProduct(Product p)
        {
            try
            {
                p.Rating = 0;
                p.NoOfRatings = 0;
                db.Product.Add(p);
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

        public bool DeleteProduct(int ProductId)
        {
            try
            {
                var data = db.Product.Where(x => x.ProductId == ProductId).FirstOrDefault();
                if (data == null)
                    return false;
                else
                {
                    db.Product.Remove(data);
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

        public List<Order> ShowAllOrdersOfSeller(string SellerEmailId)
        {
            return db.Order.Where(x => x.SellerEmailId == SellerEmailId).ToList();
        }

        public List<Product> ShowAllProductsOfSeller(string EmailId)
        {
            return db.Product.Where(x => x.EmailId == EmailId).ToList();
        }

        public Order ShowOrderById(int OrderId)
        {
            return db.Order.Where(x => x.OrderId == OrderId).FirstOrDefault();
        }

        public bool UpdateDeliveryStatus(int OrderId, string delstatus)
        {
            try
            {
                var olddata = db.Order.Where(c => c.OrderId == OrderId).FirstOrDefault();
                olddata.DeliveryStatus = delstatus;
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false ;
            }
            return false;
        }
    

        public bool UpdateProduct(int ProductId, Product p)
        {
            try
            {
                var oldData = db.Product.Where(x => x.ProductId == ProductId).FirstOrDefault();
                if (oldData == null)
                {
                    return false;
                }

                oldData.ProductQuantity = p.ProductQuantity;
                oldData.ProductPrice = p.ProductPrice;
                oldData.ShippingCost = p.ShippingCost;

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

        public bool UpdateReturnStatus(int OrderId, bool retstatus)
        {
            try
            {
                var olddata = db.Order.Where(c => c.OrderId == OrderId).FirstOrDefault();
                olddata.ReturnStatus = retstatus;
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

        public Order ShowOrderById(int OrderId)
        {
            return db.Order.Where(x => x.OrderId == OrderId).FirstOrDefault();
        }
    }
}
