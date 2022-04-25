using System;
using System.Collections.Generic;

namespace MedPro.Models.EF
{
    public partial class User
    {
        public User() { }

        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Role { get; set; }

    }
}
