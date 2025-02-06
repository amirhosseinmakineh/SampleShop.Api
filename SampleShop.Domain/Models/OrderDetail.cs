namespace SampleShop.Domain.Models
{
    public class OrderDetail:BaseEntity<long>
    {
        public long OrderId { get; set; }
        public decimal TotalOrderSum { get; set; }
        #region Relations
        public virtual Order Order { get; set; }
        #endregion
    }
}
