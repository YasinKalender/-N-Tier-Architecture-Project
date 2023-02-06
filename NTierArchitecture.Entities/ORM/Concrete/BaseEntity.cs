using NTierArchitecture.Entites.ORM.Abtsract;
using NTierArchitecture.Entites.ORM.Enums;

namespace NTierArchitecture.Entites.ORM.Concrete
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Status Status { get; set; }
    }
}
