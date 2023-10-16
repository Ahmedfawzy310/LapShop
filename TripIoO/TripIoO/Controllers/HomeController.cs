namespace TripIoO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITrip _trip;
        private readonly ISlider _slider;
        private readonly ICategory _category;
        public HomeController(ITrip trip, ISlider slider, ICategory category)
        {
            _trip = trip;
            _slider = slider;
            _category = category;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel
            {
                Sliders = _slider.GetSlider(),
                Categories = _category.GetCategories(),
                Trips = _trip.GetAll(),
                SpecialTrips=_trip.SpecialTrip(),
                NewTrips=_trip.NewArival()
            };
            return View(model);
        }

        public IActionResult About(int id)
        {
            var trip = _trip.GetById(id);
            return View(trip);
        }

       
    }
}
