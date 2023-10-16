namespace TripIoO.Setting.Attrebuites
{
    public class AllowedExtension : ValidationAttribute
    {
        private readonly string _allowedExtension;
        public AllowedExtension(string _allowedExtension)
        {
            this._allowedExtension = _allowedExtension;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null)
            {
                var extension = Path.GetExtension(file.FileName);

                var isAllowed = _allowedExtension.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase);

                if (!isAllowed)
                {
                    return new ValidationResult($"Only {_allowedExtension} are allowed");
                }

            }
            return ValidationResult.Success;
        }
    }
}


