using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiNhanSu.Models;
using QuanLiNhanSu.Repositories;

namespace QuanLiNhanSu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UsersController(IUserRepository repo)
        {
            _userRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                return Ok(await _userRepo.GetAllUserAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById (string id)
        {
            var user = await _userRepo.GetUserByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewUser(UserModel model)
        {
            try
            {
                var newUserId = await _userRepo.AddUserAsync(model);
                return Ok(newUserId);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
