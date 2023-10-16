namespace TripIoO.Services.Interfaces
{
    public interface ISalesInvoice
    {
        public List<VwSalesInvoice> GetAll();
        public TbSalesInvoice GetById(int id);
        public bool Save(TbSalesInvoice trip, List<TbSalesInvoiceTrip> trips, bool Isnew);
        public bool Delete(int id);
    }
}
