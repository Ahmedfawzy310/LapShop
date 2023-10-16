namespace TripIoO.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<TbSlider> Sliders { get; set; }=Enumerable.Empty<TbSlider>();
        public IEnumerable<TbCategory> Categories { get; set; } = Enumerable.Empty<TbCategory>();
        public IEnumerable<TbTrip> Trips { get; set; }=Enumerable.Empty<TbTrip>();
        public IEnumerable<TbTrip> NewTrips { get; set; }=Enumerable.Empty<TbTrip>();
        public IEnumerable<TbTrip> SpecialTrips { get; set; }=Enumerable.Empty<TbTrip>();

    }
}
