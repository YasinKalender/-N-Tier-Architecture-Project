namespace NTierArchitecture.Entites.ORM.Concrete
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
