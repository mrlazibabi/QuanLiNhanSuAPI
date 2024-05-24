using QuanLiNhanSu2.Entities;

namespace QuanLiNhanSu2.Services
{
    public interface IFormServices
    {
        Task<IEnumerable<Form>> GetAllAsync();
        Task<Form> GetByIdAsync(int id);
    }
}
