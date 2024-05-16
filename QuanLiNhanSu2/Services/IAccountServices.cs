using Microsoft.AspNetCore.Identity;
using QuanLiNhanSu2.Models;

namespace QuanLiNhanSu2.Services
{
    public interface IAccountServices
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}
