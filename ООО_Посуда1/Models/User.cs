using System;
using System.Collections.Generic;

namespace ООО_Посуда1.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Iduser { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronomyc { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Login { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual UserRole Role { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
