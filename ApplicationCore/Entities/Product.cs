using System.Collections.Generic;

namespace ApplicationCore.Entities
{
  public class FM_Product: BaseEntity
  {
    public FM_Product()
    {
      OrderItems = new List<FM_OrderItem>();
      PriceChanges = new List<FM_ProductChanges>();
    }

    public string F_FullName { get; set; }
    public string F_EnCode { get; set; }
    public decimal F_GuidePrice { get; set; }
    public decimal F_SalePrice { get; set; }
    public decimal F_StandardCost { get; set; }
    public string F_ImageUrl1 { get; set; }
    public UnitType F_Unit { get; set; }

    public int CatalogId { get; set; }
    public FM_ProductCarategory CatalogType { get; set; }
        public int LocalCatalogId { get; set; }
        public LocalCatalogType LocalCatalogType { get; set; }
        public List<FM_OrderItem> OrderItems { get; set; }
    public List<FM_ProductChanges> PriceChanges { get; set; }
  }
}
