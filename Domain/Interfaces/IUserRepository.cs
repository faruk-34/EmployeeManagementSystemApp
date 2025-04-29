using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> Get(int id, CancellationToken cancellationToken);
        Task<User?> GetByEmailAsync(string email);
         Task Insert(User user);
        Task Update(User user,CancellationToken cancellationToken);
    }
}
