using Microsoft.CodeAnalysis;

namespace TripIoO.Controllers
{
    public class Orders : Controller
    {
        ITrip _trip;
        ISalesInvoice _sales;
        UserManager<ApplicationUser> _userManager;
        public Orders(ITrip trip, ISalesInvoice sales, UserManager<ApplicationUser> userManager)
        {
            _trip = trip;
            _sales = sales;
            _userManager = userManager;
        }
        public IActionResult Cart()
        {
            string cookie = string.Empty;
            if (HttpContext.Request.Cookies["Key"] != null)
            {
                cookie = HttpContext.Request.Cookies["Key"];
            }

            var cart = JsonConvert.DeserializeObject<CartViewModel>(cookie);
            return View(cart);
        }

        public IActionResult AddToCart(int tripId)
        {
            var trip = _trip.GetById(tripId);


            CartViewModel cart;

            if (HttpContext.Request.Cookies["Key"] != null)
            {

                cart = JsonConvert.DeserializeObject<CartViewModel>(HttpContext.Request.Cookies["Key"]);
            }
            else
            {
                cart = new CartViewModel();

            }
            var trips = cart.TripList.Where(a => a.TripId == tripId).FirstOrDefault();
            if (trips != null)
            {
                trips.quty++;
            }
            else
            {
                cart.TripList.Add(new BookingCartViewModel
                {
                    TripId = trip.Id,
                    TripName = trip.Name,
                    Price = trip.PurchesPrice,
                    Cover = trip.Cover,
                    quty = 1
                });
            }

            cart.Total = cart.TripList.Sum(a => a.Price);


            HttpContext.Response.Cookies.Append("Key", JsonConvert.SerializeObject(cart));
            return RedirectToAction("Cart");
        }

        [Authorize]
        public async Task<IActionResult> OrderSuccess()
        {
            string cookie = string.Empty;
            if (HttpContext.Request.Cookies["Key"] != null)
                cookie = HttpContext.Request.Cookies["Key"];
            var cart = JsonConvert.DeserializeObject<CartViewModel>(cookie);
            await SaveOrder(cart);
            return View();
        }



        async Task SaveOrder(CartViewModel oShopingCart)
        {
            try
            {
                List<TbSalesInvoiceTrip> lstInvoiceItems = new List<TbSalesInvoiceTrip>();
                foreach (var trip in oShopingCart.TripList)
                {
                    lstInvoiceItems.Add(new TbSalesInvoiceTrip()
                    {
                        TripId = trip.TripId,
                        InvoicePrice = trip.Price
                    });
                }

                var user = await _userManager.GetUserAsync(User);

                TbSalesInvoice oSalesInvoice = new TbSalesInvoice()
                {
                    InvoiceDate = DateTime.Now,
                    BookerId = Guid.Parse(user.Id),
                    CreatedBy = user.UserName,
                    CreatedDate = DateTime.Now
                };

                _sales.Save(oSalesInvoice, lstInvoiceItems, true);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
       
        [HttpDelete]
        public IActionResult RemoveItem(int id)
        {
            // Retrieve cart from cookies
            CartViewModel cart = GetCartFromCookies();
           
            // Remove the item from the cart
            var itemToRemove = cart.TripList.FirstOrDefault(item => item.TripId == id);
            if (itemToRemove != null)
            {
               
                cart.TripList.Remove(itemToRemove);
                
                SaveCartToCookies(cart);
               
            }

            // Redirect to the cart view or wherever you need
            return RedirectToAction("Cart");
        }

        private CartViewModel GetCartFromCookies()
        {
            string cartJson = HttpContext.Request.Cookies["Key"];
            if (!string.IsNullOrEmpty(cartJson))
            {
                return JsonConvert.DeserializeObject<CartViewModel>(cartJson);
            }
            return new CartViewModel();
        }

        private void SaveCartToCookies(CartViewModel cart)
        {
            string cartJson = JsonConvert.SerializeObject(cart);
            HttpContext.Response.Cookies.Append("Key", cartJson);
        }


        
    }
}
