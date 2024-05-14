using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiNhanSu.Models;
using QuanLiNhanSu.Services;

namespace QuanLiNhanSu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _depService;
        public DepartmentsController(IDepartmentService depService)
        {
            _depService = depService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDeps()
        {
            try
            {
                var deps = await _depService.GetAllDeps();
                return Ok(deps);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepById(string id)
        {
            var user = await _depService.GetDepById(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(DepartmentModel model)
        {
            try
            {
                var userReturn = await _depService.AddDep(model);
                return Ok(userReturn);
            }
            catch
            {
                return BadRequest("Adding Error");
            }
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateUser(string id, UserModel model)
        //{
        //    if (id == model.Id)
        //    {
        //        await _depService.UpdateUser(id, model);
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest("Not Found");
        //    }
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                await _depService.DeleteDep(id);
                return Ok();
            }
        }
    }
}

