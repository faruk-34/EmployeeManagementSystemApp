using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
 

        public async Task<Employee> Get(int id, CancellationToken cancellationToken)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);    
     
        }

        public async Task Insert(Employee eventEntity, CancellationToken cancellationToken)
        {
            await _context.Employees.AddAsync(eventEntity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Employee eventEntity, CancellationToken cancellationToken)
        {
            _context.Employees.Update(eventEntity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var eventEntity = await _context.Employees.FindAsync(id);
            if (eventEntity != null)
            {
                _context.Employees.Remove(eventEntity);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
 
