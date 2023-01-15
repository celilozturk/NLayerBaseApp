namespace NLayer.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } //List yerine ICollection tutmak daha mantikli... Navigation Property
    }
}
