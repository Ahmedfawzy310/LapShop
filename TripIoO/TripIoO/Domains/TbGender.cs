namespace TripIoO.Domains
{
    public class TbGender:BaseIntity
    {
        public ICollection<ApplicationUser> Users { get; set; }=new List<ApplicationUser>();
    }
}
