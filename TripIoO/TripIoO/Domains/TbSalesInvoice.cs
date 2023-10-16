namespace TripIoO.Domains
{
    public class TbSalesInvoice
    {
        public int InvoiceId { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string? Notes { get; set; }

        public Guid BookerId { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public int CurrentState { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<TbSalesInvoiceTrip> TbSalesInvoiceTrips { get; set; } = new List<TbSalesInvoiceTrip>();
    }
}
