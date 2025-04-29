using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DepartmentRepository: IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Department> Get(int id, CancellationToken cancellationToken)
        {
            return await _context.Department.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        }

        public async Task Insert(Department departmentEntity, CancellationToken cancellationToken)
        {
            await _context.Department.AddAsync(departmentEntity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(Department departmentEntity, CancellationToken cancellationToken)
        {
            _context.Department.Update(departmentEntity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var departmentEntity = await _context.Department.FindAsync(id);
            if (departmentEntity != null)
            {
                _context.Department.Remove(departmentEntity);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
