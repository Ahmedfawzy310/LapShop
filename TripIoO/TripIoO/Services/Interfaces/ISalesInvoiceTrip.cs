namespace TripIoO.Services.Interfaces
{
    public interface ISalesInvoiceTrip
    {
        public List<TbSalesInvoiceTrip> GetSalesInvoiceID(int id);
        public bool Save(IList<TbSalesInvoiceTrip> trips, int salesInvoiceId, bool Isnew);
    }
}
