using QuanLiNhanSu2.Entities;
using System.Security.Claims;

namespace QuanLiNhanSu2.Helpers
{
    public class UploadHandler
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly QuanLiNhanSuContext _context;

        public UploadHandler()
        {

        }

        public UploadHandler(QuanLiNhanSuContext context)
        {
            _context = context;
        }

        //public string Upload (IFormFile file, string UserId)
        //{


        //    //extension
        //    List<string> validExtension = new List<string>() { ".jpg", ".png", ".gif", ".pdf"};
        //    string Extension = Path.GetExtension(file.FileName);
        //    if (!validExtension.Contains(Extension))
        //    {
        //        return $"Extension is not valid({string.Join(',', validExtension)})";
        //    }
        //    //file size
        //    long size = file.Length;
        //    if(size > (5 * 1024 * 1024))
        //    {
        //        return "Maximum size can be 5mb";
        //    }
        //    //name changing
        //    using (var stream = new MemoryStream())
        //    {
        //        file.CopyTo(stream);
        //    }
        //    string fileName = Guid.NewGuid().ToString() + Extension;
        //    string path = Path.Combine(Directory.GetCurrentDirectory(),"Uploads");
        //    using FileStream stream = new FileStream(Path.Combine(path,fileName), FileMode.Create);
        //    file.CopyTo(stream);

        //    _context.Forms.Add(new Form { UserId = UserId, FormName = fileName, FormData = stream });

        //    return fileName;
        //}

        public string Upload(IFormFile file, string userId)
        {
            //extension
            List<string> validExtension = new List<string>() { ".jpg", ".png", ".gif", ".pdf" };
            string Extension = Path.GetExtension(file.FileName);
            if (!validExtension.Contains(Extension))
            {
                return $"Extension is not valid({string.Join(',', validExtension)})";
            }

            //file size
            long size = file.Length;
            if (size > (5 * 1024 * 1024))
            {
                return "Maximum size can be 5mb";
            }

            var newForm = new Form
            {
                FormName = file.FileName,
                Id = userId,
                Created = DateTime.Now,

            };

            using (var streamFile = new MemoryStream())
            {
                file.CopyTo(streamFile);
                newForm.FormData = streamFile.ToArray();
            }

            _context.Forms.Add(newForm);
            _context.SaveChanges();

            //name changing
            string fileName = Guid.NewGuid().ToString() + Extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            using FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            file.CopyTo(stream);

            return fileName;
        }
    }
}
