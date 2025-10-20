using System.ComponentModel.DataAnnotations.Schema;

namespace mvcLab1.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int grade { get; set; }
        public string imageUrl { get; set; }
        public string? Address { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
