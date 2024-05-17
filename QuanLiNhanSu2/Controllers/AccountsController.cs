using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiNhanSu2.Models.AuthenModels;
using QuanLiNhanSu2.Services;

namespace QuanLiNhanSu2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountServices _accountServices;

        public AccountsController(IAccountServices services)
        {
            _accountServices = services;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            var result = await _accountServices.SignUpAsync(model);
            return Ok(result);

        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var result = await _accountServices.SignInAsync(model);
            return Ok(result);
        }
    }
}
