namespace QuanLiNhanSu2.Services
{
    public interface IUploadHandlerServices
    {
        public string Upload(IFormFile file, string userId);
    }
}
