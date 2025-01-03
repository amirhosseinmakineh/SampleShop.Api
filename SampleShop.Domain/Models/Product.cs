﻿namespace SampleShop.Domain.Models
{
    public class Product : BaseEntity<long>
    {
        public Product()
        {
            ProductDetails = new HashSet<ProductDetail>();
            Colors = new HashSet<Color>();
        }
        public string Title { get; set; } = string.Empty;
        public long CategoryId { get; set; }
        public string ImageName { get; set; } = string.Empty;
        public double Price { get; set; }

        #region Relations
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
        public virtual ICollection<Color> Colors { get; set; }
        public virtual ICollection<Featur> Featurs { get; set; }
        #endregion
    }
}
