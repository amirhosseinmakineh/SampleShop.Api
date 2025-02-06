namespace SampleShop.Domain.Models
{
    public class Order:BaseEntity<long>
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
            OrderDetails = new HashSet<OrderDetail>();
        }
        public string Name { get; set; } = string.Empty;
        public int Number { get; set; }
        public Guid UserId { get; set; }
        #region Relations
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual User User { get; set; }
        #endregion
    }
}
