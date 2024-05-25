using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu2.Entities;
using QuanLiNhanSu2.Models.QuanLiNhanSuModels;

namespace QuanLiNhanSu2.Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly QuanLiNhanSuContext _context;

        public UserRepository(IMapper mapper, QuanLiNhanSuContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<string> AddUserAsync(UserModel model)
        {
            try
            {
                var newUser = _mapper.Map<User>(model);
                _context.Users!.Add(newUser);
                await _context.SaveChangesAsync();

                return newUser.UserId;
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }
        }

        public async Task DeleteUserAsync(string id)
        {
            var deleteUser = _context.Users!.SingleOrDefault(x => x.UserId == id);
            if (deleteUser != null)
            {
                _context.Users!.Remove(deleteUser);
                await _context.SaveChangesAsync();
            };
        }

        public async Task<List<UserModel>> GetAllUserAsync()
        {
            var users = await _context.Users!.ToListAsync();
            return _mapper.Map<List<UserModel>>(users);
        }

        public async Task<UserModel> GetUserByIdAsync(string id)
        {
            var user = await _context.Users!.FindAsync(id);
            return _mapper.Map<UserModel>(user);
        }

        public async Task UpdateUserAsync(string id, UserModel model)
        {
            if (id == model.UserId)
            {
                var updateUser = _mapper.Map<User>(model);
                _context.Users!.Update(updateUser);
                await _context.SaveChangesAsync();
            }
        }
    }
}
