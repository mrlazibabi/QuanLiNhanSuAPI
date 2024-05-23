using System.Security.Claims;

namespace QuanLiNhanSu2.Services.Implements
{
    public class AppUserServices : IAppUserServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppUserServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetMyName()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext is not null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }
    }
}
