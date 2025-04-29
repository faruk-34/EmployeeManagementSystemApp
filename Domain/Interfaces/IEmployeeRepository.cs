using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> Get(int id, CancellationToken cancellationToken);
        Task Insert(Employee eventEntity, CancellationToken cancellationToken);
        Task Update(Employee eventEntity, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
