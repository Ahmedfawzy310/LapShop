namespace TripIoO.Services.Interfaces
{
    public interface IFillList
    {
        IEnumerable<SelectListItem> Categories();
        IEnumerable<SelectListItem> Countries();
        IEnumerable<SelectListItem> Cites();
        IEnumerable<SelectListItem> Genders();
    }
}
