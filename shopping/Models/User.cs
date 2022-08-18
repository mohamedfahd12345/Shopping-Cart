using System;
using System.Collections.Generic;

namespace shopping.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public int? Zipcode { get; set; }
        public string Cartid { get; set; } = null!;
    }
}
