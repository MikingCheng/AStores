namespace ApplicationCore.Entities
{
    public class FM_OrderItem : BaseEntity
    {
        public decimal F_Price { get; set; }
        public float F_Quantity { get; set; }
        public decimal F_LineTotal { get; set; }
        public OrderItemStatus Status { get; set; }

        public int F_OrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }
        public int F_ProductId { get; set; }
        public FM_Product Product { get; set; }
    }
}
