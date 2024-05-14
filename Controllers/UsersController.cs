using Microsoft.AspNetCore.Mvc;
using QuanLiNhanSu.Models;
using QuanLiNhanSu.Services;

namespace QuanLiNhanSu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService _usrService)
        {
            _userService = _usrService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var users = await _userService.GetAllUser();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUserById(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(UserModel model)
        {
            try
            {
                // var newUserId = await _userRepo.AddUserAsync(model);
                var userReturn = await _userService.AddUser(model);
                return Ok(userReturn);
            }
            catch
            {
                return BadRequest("Adding Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, UserModel model)
        {
            if (id == model.Id)
            {
                await _userService.UpdateUser(id, model);
                return Ok();
            }
            else
            {
                return BadRequest("Not Found");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                await _userService.DeleteUser(id);
                return Ok();
            }
        }
    }
}
