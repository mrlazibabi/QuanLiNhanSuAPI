using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Models.QuanLiNhanSuModels;
using QuanLiNhanSu2.Services;
using QuanLiNhanSu2.Services.Implements;
using System.Security.Claims;

namespace QuanLiNhanSu2.Controllers
{
    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUploadHandlerServices _uploadHandlerServices;
        private readonly ISalaryServices _salaryServices;

        public EmployeesController(IHttpContextAccessor httpContextAccessor, IUploadHandlerServices uploadHandlerServices, ISalaryServices salaryServices)
        {
            _httpContextAccessor = httpContextAccessor;
            _uploadHandlerServices = uploadHandlerServices;
            _salaryServices = salaryServices;
        }

        private string GetUserId()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                var tempo = _httpContextAccessor.HttpContext.User;
                result = tempo.FindFirstValue("UserId");
            }
            return result;
        }
        [HttpPost("Upload-Form")]
        [Authorize(Roles = "Employee")]
        public IActionResult UploadFile(IFormFile file)
        {
            var userId = GetUserId();
            return Ok(_uploadHandlerServices.Upload(file, userId));
        }

        [HttpGet("/Salary-User/{userId}")]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult<SalaryModel>> GetSalaryByUser(string userId)
        {
            var userSalary = await _salaryServices.GetSalaryByUserIdAsync(userId);
            if (userId == null)
            {
                return NotFound();
            }

            return userSalary;
        }

    }
}
