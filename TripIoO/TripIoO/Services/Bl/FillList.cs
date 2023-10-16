namespace TripIoO.Services.Bl
{
    public class FillList: IFillList
    {
        ApplicationDbContext _context;
        public FillList(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> Categories()
        {
            return 
                _context.TbCategories.Select(c=> new SelectListItem { Value=c.Id.ToString(), Text=c.Name}).ToList();
        }

        public IEnumerable<SelectListItem> Countries()
        {
            return
                _context.TbCountries.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .OrderBy(o=>o.Text).ToList();
        }

        public IEnumerable<SelectListItem> Cites()
        {
            return _context.TbCities.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name })
                 .OrderBy(e => e.Text).ToList();
        }

        public IEnumerable<SelectListItem> Genders()
        {
            return _context.TbGenders.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name })
                 .OrderBy(e => e.Text).ToList();
        }
    }
}
