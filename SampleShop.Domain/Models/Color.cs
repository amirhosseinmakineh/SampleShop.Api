namespace SampleShop.Domain.Models
{
    public class Color : BaseEntity<int>
    {
        public string Title { get; set; } = string.Empty;
        public long ProductI { get; set; }
        #region Relations
        public virtual Product Product { get; set; }
        #endregion
    }
}
