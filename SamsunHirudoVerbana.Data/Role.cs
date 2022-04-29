using System;
using System.Collections.Generic;

namespace SamsunHirudoVerbana.Data
{
    public partial class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public int RoleValue { get; set; }
        public bool IsDeleted { get; set; }
    }
}
