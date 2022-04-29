using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SamsunHirudoVerbana.Data
{
    public partial class User : IdentityUser
    {
        public int UserId { get; set; }
        public int? CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsVerified { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
