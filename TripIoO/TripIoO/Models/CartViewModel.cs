namespace TripIoO.Models
{
    public class CartViewModel
    {
        public List<BookingCartViewModel> TripList { get; set; }=new List<BookingCartViewModel>();
        public decimal Total { get; set; }
    }
}
