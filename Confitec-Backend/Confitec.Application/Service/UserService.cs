using AutoMapper;
using Confitec.Application.ViewModel;
using Confitec.Domain.Model;
using Confitec.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Application.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserVm>> GetAllUser()
        {
            var result = await _userRepository.GetAllUser();
            var response = _mapper.Map<List<UserVm>>(result);

            return response;
        }

        public async Task<UserVm> GetUserById(long id)
        {
            var result = await _userRepository.GetUserById(id);
            var response = _mapper.Map<UserVm>(result);

            return response;
        }

        public async Task<UserVm> AddUser(CreateUserVm userVm)
        {
            var user = _mapper.Map<User>(userVm);
            var result = await _userRepository.AddUser(user);
            var response = _mapper.Map<UserVm>(result);

            return response;
        }

        public async Task<UserVm> UpdateUser(CreateUserVm userVm, long id)
        {
            var userToUpdate = await _userRepository.GetUserById(id);
            var user = _mapper.Map(userVm, userToUpdate);

            var result = await _userRepository.UpdateUser(user);
            var response = _mapper.Map<UserVm>(result);

            return response;
        }

        public async Task Delete(long id)
        {
            var user = await _userRepository.GetUserById(id);
            await _userRepository.Delete(user);
        }

        public IEnumerable<KeyValuePair<string, int>> GetAllEducationLevel()
        {
            var response = Enum.GetValues(typeof(EducationLevel))
                    .Cast<EducationLevel>()
                    .Select(x => new KeyValuePair<string, int>(GetDescription(x), (int)x));

            return response;
        }

        private string GetDescription(EducationLevel source)
        {
            var fieldInfo = source.GetType().GetField(source.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes[0].Description;
        }

    }
}
