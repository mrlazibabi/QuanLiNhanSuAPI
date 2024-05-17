using Microsoft.AspNetCore.Identity;
using NuGet.Packaging.Signing;
using QuanLiNhanSu2.Models.AuthenModels;
using static QuanLiNhanSu2.Models.AuthenModels.ServiceResponses;

namespace QuanLiNhanSu2.Services
{
    public interface IAccountServices
    {
        public Task<GeneralResponse> SignUpAsync(SignUpModel model);
        public Task<LoginResponse> SignInAsync(SignInModel model);
    }
}
