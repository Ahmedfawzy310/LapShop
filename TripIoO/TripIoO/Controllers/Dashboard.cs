using System.Xml.Linq;
using TripIoO.Domains;

namespace TripIoO.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Dashboard : Controller
    {
        IFillList _dropObject;
        ITrip _tripObject;
        public Dashboard(IFillList dropObject, ITrip tripObject)
        {
            _dropObject = dropObject;
            _tripObject = tripObject;
        }


        [HttpGet]
        public IActionResult Create()
        {
            CreateFormViewModel model = new()
            {
                Categories=_dropObject.Categories(),
                Countries=_dropObject.Countries(),
                Cites=_dropObject.Cites()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFormViewModel model)
        {
            if (!ModelState.IsValid)
            {              
                model.Categories = _dropObject.Categories();
                model.Countries = _dropObject.Countries();
                model.Cites= _dropObject.Cites();
                return View(model);
            }

            await _tripObject.Create(model);

            return RedirectToAction(nameof(Read));

        }

        public IActionResult Read()
        {
            var trips = _tripObject.GetAll();
            return View(trips);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var trip = _tripObject.GetById(id);

            if (trip is null)
                return NotFound();

            EditFormViewModel viewModel = new()
            {
                Id = id,
                Name = trip.Name,
                Description = trip.Description,
                StartIn = trip.StartIn,
                EndIn=trip.EndIn,
                SalesPrice=trip.SalesPrice,
                PurchasePrice=trip.PurchesPrice,
                CategoryId = trip.CategoryId,
                CountryId=trip.CountryId,
                SelectCites = trip.Cites.Select(d => d.CityId).ToList(),
                Categories = _dropObject.Categories(),
                Countries = _dropObject.Countries(),
                Cites = _dropObject.Cites(),
                CurrntCover = trip.Cover
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _dropObject.Categories();
                model.Countries = _dropObject.Countries();
                model.Cites = _dropObject.Cites();
               
                return View(model);
            }

            var trip = await _tripObject.Update(model);

            if (trip is null)
                return BadRequest();

            return RedirectToAction(nameof(Read));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _tripObject.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }
    }
}
