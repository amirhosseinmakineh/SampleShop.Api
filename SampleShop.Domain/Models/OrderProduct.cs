namespace SampleShop.Domain.Models
{
    public class OrderProduct : BaseEntity<long>
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        #region Relations 
        public  virtual Order Order { get; set; }
        public  virtual Product Product { get; set; }
        #endregion
    }
}
