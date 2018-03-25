using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
  public class ProductChanges : BaseEntity
  {
    public decimal F_NewPrice { get; set; }
    public Product Product { get; set; }
    public Guid F_ProductId { get; set; }

  }
}
