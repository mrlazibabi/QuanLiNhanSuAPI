using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.IdentityModel.Tokens;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Models.AuthenModels;
using QuanLiNhanSu2.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace QuanLiNhanSu2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static ApplicationUsers user = new ApplicationUsers();
        private readonly IConfiguration _configuration;
        private readonly IAppUserServices _appUserServices;
        private readonly UserManager<ApplicationUsers> _userManager;

        public AuthController(IConfiguration configuration, IAppUserServices appUserServices,  UserManager<ApplicationUsers> userManager)
        {
            _configuration = configuration;
            _appUserServices = appUserServices;
            _userManager = userManager;
        }

        [HttpGet,Authorize]
        public ActionResult<string> GetMyName()
        {
            return Ok(_appUserServices.GetMyName());
        }

        [HttpPost("Register")]
        public async Task<IdentityResult> Register(AppUserModel request)
        {
            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.FullName = request.FullName;
            user.Email = request.Email;
            user.PasswordHash = passwordHash;

            var appUser = new ApplicationUsers
            {
                UserName = request.Email,
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = request.Password
                
            };

            var result = await _userManager.CreateAsync(appUser, request.Password);
            return result;
        }
        [HttpPost("Login")]
        //public ActionResult<ApplicationUsers> Login(AppUserModel request)
        public async Task<string> Login(AppUserModel request)
        {
            var user = await _userManager.FindByNameAsync(request.Email);

            var checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (user == null || !checkPassword)
            {
                return string.Empty;
            }

            //if (user.Email != request.Email)
            //{
            //    return BadRequest("User not found.");
            //}

            //if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            //{
            //    return BadRequest("Wrong password.");
            //}

            string token = CreateToken(user);

            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken);

            return token;
        }

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken { 
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7)
            };

            return refreshToken;
        }

        private void SetRefreshToken(RefreshToken newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires,
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
        }

        private string CreateToken(ApplicationUsers user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim("UserId", user.Id),
                new Claim(ClaimTypes.Role, "Employee")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWT:Secret").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
