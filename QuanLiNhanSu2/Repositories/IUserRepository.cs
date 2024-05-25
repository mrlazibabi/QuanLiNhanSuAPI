using QuanLiNhanSu2.Models.QuanLiNhanSuModels;

namespace QuanLiNhanSu2.Repositories
{
    public interface IUserRepository
    {
        public Task<List<UserModel>> GetAllUserAsync();
        public Task<UserModel> GetUserByIdAsync(string id);
        public Task<string> AddUserAsync(UserModel model);
        public Task UpdateUserAsync(string id, UserModel model);
        public Task DeleteUserAsync(string id);
    }
}
