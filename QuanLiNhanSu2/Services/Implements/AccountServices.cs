using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Models.AuthenModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static QuanLiNhanSu2.Models.AuthenModels.ServiceResponses;

namespace QuanLiNhanSu2.Services.Implements
{
    public class AccountServices : IAccountServices
    {
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountServices(UserManager<ApplicationUsers> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;

        }
        public async Task<LoginResponse> SignInAsync(SignInModel model)
        {
            if (model == null)
                return new LoginResponse(false, null!, "Login container is empty");

            var getUser = await _userManager.FindByEmailAsync(model.Email);
            if (getUser is null)
                return new LoginResponse(false, null!, "User not found");

            bool checkUserPasswords = await _userManager.CheckPasswordAsync(getUser, model.Password);
            if (!checkUserPasswords)
                return new LoginResponse(false, null!, "Invalid email/password");

            var getUserRole = await _userManager.GetRolesAsync(getUser);
            var userSession = new UserSession(getUser.FullName, getUser.Email, getUserRole.First());
            string token = GenerateToken(userSession);
            return new LoginResponse(true, token!, "Login completed");
        }

        private string GenerateToken(UserSession user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:ValidIssuer"],
                audience: _configuration["Jwt:ValidAudience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<GeneralResponse> SignUpAsync(SignUpModel model)
        {
            if (model is null) return new GeneralResponse(false, "Model is empty");
            var newUser = new ApplicationUsers()
            {
                FullName = model.FullName,
                Email = model.Email,
                PasswordHash = model.Password,
                UserName = model.Email
            };
            var user = await _userManager.FindByEmailAsync(newUser.Email);
            if (user is not null) return new GeneralResponse(false, "User registered already");

            var createUser = await _userManager.CreateAsync(newUser!, model.Password);
            if (!createUser.Succeeded) return new GeneralResponse(false, "Error occured.. please try again");

            //Assign Default Role : Admin to first registrar; rest is employee
            var checkAdmin = await _roleManager.FindByNameAsync("Admin");
            if (checkAdmin is null)
            {
                await _roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
                await _userManager.AddToRoleAsync(newUser, "Admin");
                return new GeneralResponse(true, "Account Created");
            }
            else
            {
                var checkUser = await _roleManager.FindByNameAsync("Employee");
                if (checkUser is null)
                    await _roleManager.CreateAsync(new IdentityRole() { Name = "Employee" });

                await _userManager.AddToRoleAsync(newUser, "Employee");
                return new GeneralResponse(true, "Account Created");
            }
        }
    }
}
