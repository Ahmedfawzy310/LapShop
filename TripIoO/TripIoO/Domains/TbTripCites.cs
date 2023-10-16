namespace TripIoO.Domains
{
    public class TbTripCites
    {
        public int TripId { get; set; }
        public TbTrip Trip { get; set; } = default!;

        public int CityId { get; set; }
        public TbCity City { get; set; }=default!;
    }
}
