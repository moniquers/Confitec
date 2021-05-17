using Confitec.Application.Service;
using Confitec.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Confitec.Api.Controllers
{
    [Route("[controller]")]
    public class UserController: ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetAllUser();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var result = await _userService.GetUserById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserVm userVm)
        {
            var response = await _userService.AddUser(userVm);

            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CreateUserVm userVm, long id)
        {
            var response = await _userService.UpdateUser(userVm, id);

            return Ok(response.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _userService.Delete(id);
            return Ok();
        }

        [HttpGet("EducationLevel")]
        public IActionResult GetAllEducationLevel()
        {
            var response = _userService.GetAllEducationLevel();

            return Ok(response);
        }
    }
}
