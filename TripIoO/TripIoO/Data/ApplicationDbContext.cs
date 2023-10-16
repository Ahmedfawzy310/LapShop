namespace TripIoO.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TbTrip> TbTrips { get; set; }
        public DbSet<TbCategory> TbCategories { get; set; }
        public DbSet<TbCountry> TbCountries { get; set; }
        public DbSet<TbCity> TbCities { get; set; }
        public DbSet<TbTripCites> TbTripCites { get; set; }
        public DbSet<TbSetting> TbSettings { get; set; }
        public DbSet<TbSlider> TbSliders { get; set; }
        public DbSet<TbGender> TbGenders { get; set; }
        public DbSet<TbSalesInvoice> TbSalesInvoices { get; set; }
        public DbSet<TbSalesInvoiceTrip> TbSalesInvoiceTrips { get; set; }
        public DbSet<VwSalesInvoice> VwSalesInvoices { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<TbTripCites>()
               .HasKey(e => new { e.CityId, e.TripId });

            builder.Entity<TbCategory>(entity =>
            {
                entity.Property(e => e.Image).IsRequired(false);
            });

            builder.Entity<TbSalesInvoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(N'')");
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
                entity.Property(e => e.InvoiceDate)
                    .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            });

            builder.Entity<TbSalesInvoiceTrip>(entity =>
            {
                entity.HasKey(e => e.InvoiceItemId);

                entity.Property(e => e.InvoicePrice).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.Invoice).WithMany(p => p.TbSalesInvoiceTrips)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbSalesInvoiceItems_TbSalesInvoices");

                entity.HasOne(d => d.Trip).WithMany(p => p.TbSalesInvoiceTrips)
                    .HasForeignKey(d => d.TripId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbSalesInvoiceItems_TbItems");
            });

            builder.Entity<VwSalesInvoice>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("VwSalesInvoices");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            });
            base.OnModelCreating(builder);

        }
    }
}
