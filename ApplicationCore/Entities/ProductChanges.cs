using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
  public class FM_ProductChanges : BaseEntity
  {
    public FM_Product Product { get; set; }
    public int F_ProductId { get; set; }

    public decimal F_NewPrice { get; set; }

  }
}
