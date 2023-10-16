namespace TripIoO.Domains
{
    public class TbCategory:BaseIntity
    {
        public int CurrentState { get; set; }
        public string? Image { get; set; } =string.Empty;


        public ICollection<TbTrip>Trips { get; set; }=new List<TbTrip>();
    }
}
