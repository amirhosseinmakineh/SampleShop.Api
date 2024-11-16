namespace SampleShop.Domain.Models
{
    public class Featur : BaseEntity<long>
    {
        public string Name { get; set; } = string.Empty;
        public long ProductId { get; set; }
        #region Relations
        public virtual Product Product { get; set; }
        #endregion
    }
}
