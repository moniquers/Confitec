using Confitec.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.Infrastructure.Data.Repository
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task Delete(User user);
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(long id);
        Task<User> UpdateUser(User user);
    }
}