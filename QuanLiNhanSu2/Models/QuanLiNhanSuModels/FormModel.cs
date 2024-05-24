using QuanLiNhanSu2.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiNhanSu2.Models.QuanLiNhanSuModels
{
    public class FormModel
    { 
        public int FormId { get; set; }
        public string Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string FormName { get; set; }
        public byte[] FormData { get; set; }
    }
}
