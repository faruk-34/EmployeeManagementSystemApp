using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> Get(int id, CancellationToken cancellationToken);

        Task<List<Employee>> GetAll(CancellationToken cancellationToken);
        Task Insert(Employee employeeEntity, CancellationToken cancellationToken);
        Task Update(Employee employeeEntity, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
