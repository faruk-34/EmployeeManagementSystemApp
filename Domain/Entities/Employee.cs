namespace Domain.Entities
{
    public class Employee : BaseEntity, ISoftDeletable
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
     }
}
