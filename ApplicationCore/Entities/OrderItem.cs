using System;
namespace ApplicationCore.Entities
{
  public class OrderItem : BaseEntity
  {
    public decimal F_Price { get; set; }
    public float F_Quantity { get; set; }
    public decimal F_LineTotal { get; set; }

    public Guid OrderItemStatusId { get; set; }
    public OrderItemStatus F_OrderItemStatus { get; set; }

    public Guid F_SalesOrderId { get; set; }
    public SalesOrder SalesOrder { get; set; }
    public Guid F_ProductId { get; set; }
    public Product Product { get; set; }
  }
}
