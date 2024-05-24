namespace QuanLiNhanSu2.Models.QuanLiNhanSuModels
{
    public class SalaryModel
    {
        public int SalaryId { get; set; }
        public string UserId { get; set; }
        public long BaseSalary { get; set; }
        public int AllowedOff { get; set; }
        public int ActualOff { get; set; }
        public long? Bonus { get; set; }
        public long? Deduction { get; set; }
        public long Final { get; set; }
    }
}
