using System;
using System.Collections.Generic;

namespace ООО_Посуда1.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int Idproduct { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Photo { get; set; }
        public string Cost { get; set; } = null!;
        public sbyte Discount { get; set; }
        public int Amount { get; set; }
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; } = null!;
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
