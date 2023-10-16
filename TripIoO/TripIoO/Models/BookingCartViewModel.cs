namespace TripIoO.Models
{
    public class BookingCartViewModel
    {
        public int TripId { get; set; }
        public string TripName { get; set; }=string.Empty;
        public decimal Price { get; set; }
        public string Cover { get; set; } = string.Empty;
        public int quty { get; set; }
    }
}
