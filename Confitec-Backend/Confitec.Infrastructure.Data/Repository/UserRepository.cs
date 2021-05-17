using Confitec.Domain.Model;
using Confitec.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.Infrastructure.Data.Repository
{
    public class UserRepository: IUserRepository
    {

        private readonly DatabaseContext _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(DatabaseContext databaseContext)
        {
            _context = databaseContext;
            _dbSet = _context.Set<User>();
        }

        public async Task<List<User>> GetAllUser()
        {
            var result = await _dbSet.ToListAsync();
            return result;
        }

        public async Task<User> GetUserById(long id)
        {
            var result = await _dbSet.SingleOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<User> AddUser(User user)
        {
            var result = await _dbSet.AddAsync(user);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = _dbSet.Update(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(User user)
        {
            _dbSet.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
