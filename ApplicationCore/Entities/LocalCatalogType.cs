using System.Collections.Generic;

namespace ApplicationCore.Entities
{
  public class LocalCatalogType : BaseEntity
    {
        public string F_FullName { get; set; }
        public List<Product> Products { get; set; }
  }
}
