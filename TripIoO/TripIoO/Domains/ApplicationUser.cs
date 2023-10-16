namespace TripIoO.Domains
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public float Age { get; set; }
        
        public int GenderId { get; set; }
        public TbGender Gender { get; set; } = default!;

        public int CountryId { get; set; }
        public TbCountry Country { get; set; } = default!;
    }
}
