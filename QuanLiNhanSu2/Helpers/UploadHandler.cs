namespace QuanLiNhanSu2.Helpers
{
    public class UploadHandler
    {
        public string Upload (IFormFile file)
        {
            //extension
            List<string> validExtension = new List<string>() { ".jpg", ".png", ".gif"};
            string Extension = Path.GetExtension(file.FileName);
            if (!validExtension.Contains(Extension))
            {
                return $"Extension is not valid({string.Join(',', validExtension)})";
            }
            //file size
            long size = file.Length;
            if(size > (5 * 1024 * 1024))
            {
                return "Maximum size can be 5mb";
            }
            //name changing
            string fileName = Guid.NewGuid().ToString() + Extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(),"Uploads");
            using FileStream stream = new FileStream(Path.Combine(path,fileName), FileMode.Create);
            file.CopyTo(stream);
            
            return fileName;
        }
    }
}
