namespace TripIoO.Services.Bl
{
    public class Setting: ISetting
    {
        ApplicationDbContext _context;
        public Setting(ApplicationDbContext context)
        {
            _context = context;
        }


        public TbSetting? Get()
        {
            return _context.TbSettings.FirstOrDefault();
        }

        public bool Save(TbSetting set)
        {
            if (set.Id == 0)
            {
                _context.TbSettings.Add(set);
            }
            else
            {
                _context.Entry(set).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            _context.SaveChanges();
            return true;
        }
    }
}
