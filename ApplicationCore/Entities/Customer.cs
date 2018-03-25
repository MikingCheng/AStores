using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
  public class Customer: BaseEntity
  {
    public string  F_Account { get; set; }
    public string F_FirstName { get; set; }
    public string F_LastName { get; set; }
    public string F_Address { get; set; }
    public Sex F_Sex { get; set; }
    public string F_MobilePhone { get; set; }

    public List<SalesOrder> SalesOrders { get; set; }
  }

  public enum Sex
  {
      Male,
      Female
  }
}
