namespace TripIoO.Domains
{
    public class TbTrip:BaseIntity
    {
        public decimal SalesPrice { get; set; }
        public decimal PurchesPrice { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CurrentState { get; set; }
        public DateTime StartIn { get; set; }
        public DateTime EndIn { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set;}
        public string? CreatedBy { get; set; }=string.Empty;
        public string? UpdatedBy { get; set; }=string.Empty;
        public string Cover { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public TbCategory Category { get; set; } = default!;

        public int CountryId { get; set; }
        public TbCountry Country { get; set; } = default!;

        public ICollection<TbTripCites> Cites { get; set; }=new List<TbTripCites>();
        public ICollection<TbSalesInvoiceTrip> TbSalesInvoiceTrips { get; set; } = new List<TbSalesInvoiceTrip>();

    }
}
