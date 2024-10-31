namespace SampleShop.Domain.Models
{
    public class BaseEntity<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateObjectDat { get; set; }
    }
}
