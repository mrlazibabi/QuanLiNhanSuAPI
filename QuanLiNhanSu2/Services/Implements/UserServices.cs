using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Models.QuanLiNhanSuModels;
using QuanLiNhanSu2.Repositories;

namespace QuanLiNhanSu2.Services.Implements
{
    public class UserServices : IUserServices
    {
        private readonly IMapper _mapper;
        private readonly QuanLiNhanSuContext _context;
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> AddUserAsync(UserModel model)
        {
            return await _userRepository.AddUserAsync(model);
        }

        public Task DeleteUserAsync(string id)
        {
            return _userRepository.DeleteUserAsync(id);
        }

        public Task<List<UserModel>> GetAllUserAsync()
        {
            return _userRepository.GetAllUserAsync();
        }

        public Task<UserModel> GetUserByIdAsync(string id)
        {
            return _userRepository.GetUserByIdAsync(id);
        }

        public Task UpdateUserAsync(string id, UserModel model)
        {
            return _userRepository.UpdateUserAsync(id, model);
        }
    }
}
