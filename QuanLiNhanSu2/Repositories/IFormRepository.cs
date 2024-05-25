using QuanLiNhanSu2.Entities;

namespace QuanLiNhanSu2.Repositories
{
    public interface IFormRepository
    {
        Task<IEnumerable<Form>> GetAllAsync();
        Task<Form> GetByIdAsync(int id);
    }
}
