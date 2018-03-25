using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class OrderItemStatus: BaseEntity
    {
        public string  F_OrderItemStatus { get; set; }
        public List<OrderItem> OrderItems { get; set; }
  }
}
