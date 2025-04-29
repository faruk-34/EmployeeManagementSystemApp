namespace Domain.Entities
{
    public class Department : BaseEntity, ISoftDeletable
    {
        public string Name { get; set; }
     }
}
