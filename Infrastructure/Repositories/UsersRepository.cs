
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Insert(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> Get(int id,CancellationToken cancellationToken)
        {
            return await _context.User.FindAsync(id,cancellationToken);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.User
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

 

        public async Task Update(User user,CancellationToken cancellationToken)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }
 
    }

}
