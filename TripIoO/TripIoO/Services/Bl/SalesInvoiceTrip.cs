namespace TripIoO.Services.Bl
{
    public class SalesInvoiceTrip:ISalesInvoiceTrip
    {
        ApplicationDbContext _context;
        public SalesInvoiceTrip(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<TbSalesInvoiceTrip> GetSalesInvoiceID(int id)
        {
            try
            {
                var trip = _context.TbSalesInvoiceTrips.Where(a => a.InvoiceId == id).ToList();
                if (trip == null)
                    return new List<TbSalesInvoiceTrip>();
                else
                    return trip;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }


        public bool Save(IList<TbSalesInvoiceTrip> trips, int salesInvoiceId, bool Isnew)
        {
            List<TbSalesInvoiceTrip> dbInvoiceTrips =
               GetSalesInvoiceID(trips[0].InvoiceId);

            foreach (var interfaceTrips in trips)
            {
                var dbObject = dbInvoiceTrips.Where(a => a.InvoiceItemId == interfaceTrips.InvoiceItemId).FirstOrDefault();
                if (dbObject != null)
                {
                    _context.Entry(dbObject).State = EntityState.Modified;
                }

                else
                {
                    interfaceTrips.InvoiceId = salesInvoiceId;
                    _context.TbSalesInvoiceTrips.Add(interfaceTrips);
                }
            }

            foreach (var trip in dbInvoiceTrips)
            {
                var interfaceObject = trips.Where(a => a.InvoiceItemId == trip.InvoiceItemId).FirstOrDefault();
                if (interfaceObject == null)
                    _context.TbSalesInvoiceTrips.Remove(trip);
            }

            _context.SaveChanges();
            return true;
        }
    }
}
