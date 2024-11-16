namespace SampleShop.Domain.Models
{
    public class ProductDetail : BaseEntity<long>
    {
        public string Description { get; set; } = string.Empty;
        public long ProductId { get; set; }
        #region Relations
        public virtual Product Product { get; set; }
        #endregion
    }
}
