using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace TripIoO.Services.Bl
{
    public class Trip: ITrip
    {
        ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _ImagePath;
        public Trip(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;    
            _webHostEnvironment = webHostEnvironment;
            _ImagePath = $"{_webHostEnvironment.WebRootPath}{FormSetting.ImagePath}";
        }


        public async Task Create(CreateFormViewModel model)
        {
            var coverName = await SaveCover(model.Cover);

            TbTrip trip = new()
            {
                CreatedDate=DateTime.Now,
                CurrentState = 1,
                Name = model.Name,
                Description=model.Description,
                StartIn = model.StartIn,
                EndIn = model.EndIn,
                SalesPrice= model.SalesPrice,
                PurchesPrice=model.PurchasePrice,
                Cover=coverName,
                CategoryId=model.CategoryId,
                CountryId=model.CountryId,
                Cites=model.SelectCites.Select(c => new TbTripCites{CityId=c}).ToList()
            };

            _context.Add(trip);

            _context.SaveChanges();
        }

        public IEnumerable<TbTrip> GetAll()
        {
            return _context.TbTrips.Include(c=>c.Category).Include(c=>c.Country)
                    .Include(c=>c.Cites).ThenInclude(c=>c.City).AsNoTracking().ToList();
        }

        public IEnumerable<TbTrip> SpecialTrip()
        {
            return _context.TbTrips.OrderByDescending(a=>a.PurchesPrice)
                .Include(c => c.Category)
                .Include(c => c.Country)
                .Include(c => c.Cites).ThenInclude(c => c.City)
                .AsNoTracking().Take(4).ToList();
        }

        public IEnumerable<TbTrip> NewArival()
        {
            return _context.TbTrips.OrderByDescending(d=>d.CreatedDate)
                .Include(c => c.Category).Include(c => c.Country)
                .Include(c => c.Cites).ThenInclude(c => c.City)
                .AsNoTracking().Take(4).ToList();
        }

        public TbTrip? GetById(int id)
        {
            return _context.TbTrips
                .Include(g => g.Category)
                .Include(g => g.Country)
                .Include(g => g.Cites)
                .ThenInclude(d => d.City)
                .AsNoTracking()
                .SingleOrDefault(g => g.Id == id);
        }

       


        public async Task<TbTrip?> Update(EditFormViewModel model)
        {
            var trip = _context.TbTrips
                .Include(g => g.Cites)
                .SingleOrDefault(g => g.Id == model.Id);

            if (trip is null)
                return null;

            var hasNewCover = model.Cover is not null;
            var oldCover = trip.Cover;
            trip.CurrentState = 1;
            trip.UpdatedDate = DateTime.Now;
            trip.Name = model.Name;
            trip.Description = model.Description;
            trip.CategoryId = model.CategoryId;
            trip.CountryId = model.CountryId;
            trip.SalesPrice = model.SalesPrice;
            trip.PurchesPrice = model.PurchasePrice;
            trip.StartIn=model.StartIn;
            trip.EndIn=model.EndIn;
            trip.Cites = model.SelectCites.Select(d => new TbTripCites { CityId = d }).ToList();

            if (hasNewCover)
            {
                trip.Cover = await SaveCover(model.Cover!);
            }

            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                if (hasNewCover)
                {
                    var cover = Path.Combine(_ImagePath, oldCover);
                    File.Delete(cover);
                }

                return trip;
            }
            else
            {
                var cover = Path.Combine(_ImagePath, trip.Cover);
                File.Delete(cover);

                return null;
            }
        }

        public bool Delete(int id)
        {
            var isDeleted = false;

            var trip = _context.TbTrips.Find(id);

            if (trip is null)
                return isDeleted;

           
            _context.Remove(trip);
            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                isDeleted = true;

                var cover = Path.Combine(_ImagePath, trip.Cover);
                File.Delete(cover);
            }

            return isDeleted;
        }



        
        private async Task<string> SaveCover(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";

            var path = Path.Combine(_ImagePath, coverName);

            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);

            return coverName;
        }


    }
}
