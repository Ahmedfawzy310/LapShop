namespace TripIoO.Services.Interfaces
{
    public interface ITrip
    {
        Task Create(CreateFormViewModel model);
        IEnumerable<TbTrip> GetAll();
        IEnumerable<TbTrip> SpecialTrip();
        IEnumerable<TbTrip> NewArival();
        TbTrip? GetById(int id);
        Task<TbTrip?> Update(EditFormViewModel model);
        bool Delete(int id);
       
    }
}
