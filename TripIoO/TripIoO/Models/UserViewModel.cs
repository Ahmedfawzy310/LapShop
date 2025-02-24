﻿namespace TripIoO.Models
{
    public class UserViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public float Age { get; set; }
        public required IEnumerable<string> Roles { get; set; }
    }
}
