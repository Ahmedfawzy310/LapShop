namespace TripIoO.Domains
{
    public class TbSalesInvoiceTrip
    {
        public int InvoiceItemId { get; set; }

        public int TripId { get; set; }

        public int InvoiceId { get; set; }

        public decimal InvoicePrice { get; set; }

        public string? Notes { get; set; }

        public virtual TbSalesInvoice Invoice { get; set; } = null!;

        public virtual TbTrip Trip { get; set; } = null!;
    }
}
