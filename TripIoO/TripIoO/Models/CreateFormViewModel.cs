namespace TripIoO.Models
{
    public class CreateFormViewModel
    {
        [MinLength(5,ErrorMessage ="Down Length")]
        [MaxLength(100,ErrorMessage ="Over Length")]
        public string Name { get; set; }=string.Empty;

        [MinLength(20,ErrorMessage ="Down Length")]
        public string Description { get; set; } = string.Empty;

        [Display(Name="Start In")]
        public DateTime StartIn { get; set; }

        [Display(Name = "End In")]
        public DateTime EndIn { get; set; }

        [Display(Name ="Sales Price")]
        public decimal SalesPrice { get; set; }

        [Display(Name ="Purchase Price")]
        public decimal PurchasePrice { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [AllowedExtension(FormSetting.AllowdExtension),
         AllowedFileSize(FormSetting.AllowdFileSizeByByte)   ]
        public IFormFile Cover { get; set; } = default!;
        public List<int>SelectCites { get; set; }=default!;
        public IEnumerable<SelectListItem> Categories { get; set; }=Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Countries { get; set; }=Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Cites { get; set; }=Enumerable.Empty<SelectListItem>();


    }
}
