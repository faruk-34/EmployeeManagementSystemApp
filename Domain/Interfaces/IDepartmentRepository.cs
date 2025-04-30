using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department> Get(int id, CancellationToken cancellationToken);
        Task<List<Department>> GetAll(CancellationToken cancellationToken);
        Task Insert(Department departmentEntity, CancellationToken cancellationToken);
        Task Update(Department departmentEntity, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
