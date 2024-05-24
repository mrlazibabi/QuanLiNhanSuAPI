using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiNhanSu2.Helpers;
using QuanLiNhanSu2.Services;
using QuanLiNhanSu2.Services.Implements;
using System.Security.Claims;

namespace QuanLiNhanSu2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Employee")]
    public class FileUploadController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUploadHandlerServices _uploadHandlerSercices;

        public FileUploadController(IHttpContextAccessor httpContextAccessor, IUploadHandlerServices uploadHandlerSercices)
        {
            _httpContextAccessor = httpContextAccessor;
            _uploadHandlerSercices = uploadHandlerSercices;
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
        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            var userId = GetUserId();   

            return Ok(_uploadHandlerSercices.Upload(file, userId));
        }
    }
}
