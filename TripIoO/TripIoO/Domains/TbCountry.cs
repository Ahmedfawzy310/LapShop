namespace TripIoO.Domains
{
    public class TbCountry:BaseIntity
    {
        public ICollection<TbTrip> Trips { get; set; }=new List<TbTrip>();
        public ICollection<ApplicationUser>Users { get; set; }= new List<ApplicationUser>();
    }
}
