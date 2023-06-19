using System;
using System.Collections.Generic;

namespace ООО_Посуда1.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int Idorder { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public string OrderDate { get; set; } = null!;
        public int PickupCode { get; set; }
        public int UserId { get; set; }
        public int PickupPointId { get; set; }
        public int OrderStatusId { get; set; }

        public virtual OrderStatus OrderStatus { get; set; } = null!;
        public virtual PickupPoint PickupPoint { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
