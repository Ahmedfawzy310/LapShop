namespace TripIoO.Services.Bl
{
    public class Category:ICategory
    {
        ApplicationDbContext _context;
        public Category(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TbCategory> GetCategories()
        {
            return _context.TbCategories.ToList();
        }
    }
}
