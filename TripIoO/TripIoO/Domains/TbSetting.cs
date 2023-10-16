namespace TripIoO.Domains
{
    public class TbSetting
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string FacebookLink { get; set; } = string.Empty;
        [Required, MaxLength(200)]
        public string InstagramLink { get; set; } = string.Empty;
        [Required, MaxLength(200)]
        public string TwiterLink { get; set; } = string.Empty;
        [Required, MaxLength(200)]
        public string GithupLink { get; set; } = string.Empty;
        [Required, MaxLength(200)]
        public string LinkedinLink { get; set; } = string.Empty;
    }
}
