using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Helpers;
using QuanLiNhanSu2.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuanLiNhanSu2.Services.Implements
{
    public class AccountServices : IAccountServices
    {
        private UserManager<ApplicationUsers> userManager;
        private SignInManager<ApplicationUsers> signInManager;
        private IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountServices(UserManager<ApplicationUsers> userManager, SignInManager<ApplicationUsers> signInManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.roleManager = roleManager;
        }
        public async Task<string> SignInAsync(SignInModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            var passwordValid = await userManager.CheckPasswordAsync(user, model.Password);

            if (user == null || !passwordValid)
            {
                return string.Empty;
            }

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (!result.Succeeded)
            {
                return string.Empty;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new ApplicationUsers
            {
                FullName = model.FullName,
                Email = model.Email,
                UserName = model.Email,
                //Role = model.Role
            };
            var result = await userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                //kiem tra role Employee da co hay chua
                if(!await roleManager.RoleExistsAsync(ApplicationRole.Employee))
                {
                    await roleManager.CreateAsync(new IdentityRole(ApplicationRole.Employee));
                }
                await userManager.AddToRoleAsync(user, ApplicationRole.Employee);
            }

            return result;
        }
    }
}
