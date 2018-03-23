using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Entities
{
  public class SalesOrder:BaseEntity
  {
    List<FM_OrderItem> _items;
    public SalesOrder()
    {
      _items = new List<FM_OrderItem>();
    }

    public string F_OrderNumber { get; set; }
    public DateTime F_OrderDate { get; set; }
        public DateTime F_PayDate { get; set; }
    public decimal F_SubTotal { get; set; }
    public decimal F_TaxAmt { get; set; } = 0;
    public decimal F_TotalDue { get; set; }
        public RefundStatus F_RefundStatus { get; set; }

    public IReadOnlyList<FM_OrderItem> OrderItems => _items.AsReadOnly();

    public int F_PaymentTypeId { get; set; }
    public int F_OderStatusId { get; set; }
    public int BuyerId { get; set; } = 0;

    public void AddOrderItem(FM_OrderItem item )
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


  public enum RefundStatus
    {
    Active,
    Unpayed,
    Deleted,
  }
}
