using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Entities
{
  public class SalesOrder:BaseEntity
  {
    List<OrderItem> _items;
    public SalesOrder()
    {
      _items = new List<OrderItem>();
    }

    public string F_OrderNumber { get; set; }
    public DateTime F_OrderDate { get; set; }
    public DateTime F_PayDate { get; set; }
    public decimal F_SubTotal { get; set; }
    public decimal F_TaxAmt { get; set; } = 0;
    public decimal F_TotalDue { get; set; }

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

    public Guid PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }

    public Guid OrderStatusId { get; set; }
    public OrderStatus OrderStatus { get; set; }

    public IReadOnlyList<OrderItem> OrderItems => _items.AsReadOnly();
    public void AddOrderItem(OrderItem item )
    {
      if(!_items.Any(i=>i.F_ProductId == item.F_ProductId))
      {
        _items.Add(item);
        return;
      }
      var existItem = _items.FirstOrDefault(i => i.F_ProductId == item.F_ProductId);
      existItem.F_Quantity += item.F_Quantity;
    }
  }
}
