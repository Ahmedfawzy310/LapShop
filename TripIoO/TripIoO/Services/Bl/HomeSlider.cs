namespace TripIoO.Services.Bl
{
    public class HomeSlider: ISlider
    {
        ApplicationDbContext _context;
        public HomeSlider(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TbSlider> GetSlider()
        {
            return _context.TbSliders.ToList();
        } 
    }
}
