namespace TripIoO.Setting.Attrebuites
{
    public class AllowedFileSize : ValidationAttribute
    {
        private readonly int _allowedsize;
        public AllowedFileSize(int _allowedsize)
        {
            this._allowedsize = _allowedsize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null)
            {


                if (file.Length > _allowedsize)
                {
                    return new ValidationResult($"Maximum allowed size is {_allowedsize}bytes");
                }

            }
            return ValidationResult.Success;
        }
    
    }
}
