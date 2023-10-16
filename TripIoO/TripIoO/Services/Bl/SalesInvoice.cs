namespace TripIoO.Services.Bl
{
    public class SalesInvoice:ISalesInvoice
    {
        ISalesInvoiceTrip _salesInvoiceTrip;
        ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;
        public SalesInvoice(ISalesInvoiceTrip salesInvoiceTrip, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _salesInvoiceTrip = salesInvoiceTrip;
            _context = context;
            _userManager = userManager;
        }



        public List<VwSalesInvoice> GetAll()
        {
            try
            {
                var invoices = _context.VwSalesInvoices.ToList();
                if (invoices != null)
                    return invoices;
                else
                    return new List<VwSalesInvoice>();

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public TbSalesInvoice GetById(int id)
        {
            try
            {
                var invoice = _context.TbSalesInvoices.Where(a => a.InvoiceId == id).FirstOrDefault();
                if (invoice != null)
                    return invoice;
                else
                    return new TbSalesInvoice();

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }


        public bool Save(TbSalesInvoice trip, List<TbSalesInvoiceTrip> trips, bool Isnew)
        {

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                trip.CurrentState = 1;
                if (Isnew)
                {
                    
                    trip.CreatedDate = DateTime.Now;
                    _context.TbSalesInvoices.Add(trip);
                }
                else
                {
                    trip.UpdatedBy = "1";
                    trip.UpdatedDate = DateTime.Now;
                    _context.Entry(trip).State = EntityState.Modified;
                }
                _context.SaveChanges();
                _salesInvoiceTrip.Save(trips, trip.InvoiceId, true);

                transaction.Commit();
                return true;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var invoice = _context.TbSalesInvoices.Where(a => a.InvoiceId == id).FirstOrDefault();
                if (invoice == null)
                    return false;
                else
                    _context.TbSalesInvoices.Remove(invoice);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
