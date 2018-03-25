using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
  public class OrderStatus:BaseEntity
  {
    public string F_OrderStatus { get; set; }
    public List<SalesOrder> SalesOrders { get; set; }
  }
}
