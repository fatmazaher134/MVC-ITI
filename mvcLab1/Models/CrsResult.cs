using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcLab1.Models
{
    public class CrsResult
    {
        
        public int TraineeId { get; set; } 
        public Trainee Trainee { get; set; }
        
        public int CourseId { get; set; } 
        public Course Course { get; set; }
        public int Degree { get; set; }
    }
}
