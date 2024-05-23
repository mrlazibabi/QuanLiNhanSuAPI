using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiNhanSu2.Models.QuanLiNhanSuModels;
using QuanLiNhanSu2.Services;

namespace QuanLiNhanSu2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userServices.GetAllUserAsync();
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
            var user = await _userServices.GetUserByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel model)
        {
            try
            {
                var newUser = await _userServices.AddUserAsync(model);
                return Ok(newUser);
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
                await _userServices.UpdateUserAsync(id, model);
                return Ok();
            }
            else
            {
                return BadRequest($"{id} not found");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUser(string id)
        {
            if (id == null)
            {
                return BadRequest($"{id} not found");
            }
            else
            {
                await _userServices.DeleteUserAsync(id);
                return Ok();
            }
        }
    }
}
