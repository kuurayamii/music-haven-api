using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHaven.Models
{
    [Table("Exams")]
    public class Exam
    {
        public Guid Id { get; set; }
        public Guid EmployeeID { get; set; }
        public DateTime Exam_date { get; set; }
        public string Type { get; set; }
        public string Result { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
