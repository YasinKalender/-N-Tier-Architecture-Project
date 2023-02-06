namespace NTierArchitecture.Entites.ORM.Concrete
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string ProdcutDescription { get; set; }
        public string Color { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
