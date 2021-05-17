using Confitec.Application.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.Application.Service
{
    public interface IUserService
    {
        Task<UserVm> AddUser(CreateUserVm userVm);
        Task Delete(long id);
        IEnumerable<KeyValuePair<string, int>> GetAllEducationLevel();
        Task<List<UserVm>> GetAllUser();
        Task<UserVm> GetUserById(long id);
        Task<UserVm> UpdateUser(CreateUserVm userVm, long id);
    }
}