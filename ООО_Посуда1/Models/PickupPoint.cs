using System;
using System.Collections.Generic;

namespace ООО_Посуда1.Models
{
    public partial class PickupPoint
    {
        public PickupPoint()
        {
            Orders = new HashSet<Order>();
        }

        public int Idpickuppoint { get; set; }
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string Home { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
