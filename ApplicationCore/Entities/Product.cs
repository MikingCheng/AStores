using System.Collections.Generic;

namespace ApplicationCore.Entities
{
  public class Product: BaseEntity
  {
    public Product()
    {
      OrderItems = new List<OrderItem>();
      PriceChanges = new List<ProductChanges>();
    }

    public string F_FullName { get; set; }
    public string F_EnCode { get; set; }
    public decimal F_GuidePrice { get; set; }
    public decimal F_SalePrice { get; set; }
    public decimal F_StandardCost { get; set; }
    public string F_ImageUrl1 { get; set; }

    public int CatalogId { get; set; }
    public CatalogType CatalogType { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public List<ProductChanges> PriceChanges { get; set; }
  }
}
