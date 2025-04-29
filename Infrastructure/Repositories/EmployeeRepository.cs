using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
 

        public async Task<Employee> Get(int id, CancellationToken cancellationToken)
        {
            return await _context.Employee.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);    
     
        }

        public async Task Insert(Employee employeeEntity, CancellationToken cancellationToken)
        {
            await _context.Employee.AddAsync(employeeEntity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Employee employeeEntity, CancellationToken cancellationToken)
        {
            _context.Employee.Update(employeeEntity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var employeeEntity = await _context.Employee.FindAsync(id);
            if (employeeEntity != null)
            {
                _context.Employee.Remove(employeeEntity);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
 
