namespace TripIoO.Domains
{
    public partial class VwSalesInvoice
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int InvoiceId { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string? Notes { get; set; }

        public Guid BookerId { get; set; }
    }
}
