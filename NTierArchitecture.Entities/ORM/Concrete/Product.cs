namespace NTierArchitecture.Entites.ORM.Concrete
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int ProductFeatureId { get; set; }
        public virtual ProductFeature ProductFeature { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

