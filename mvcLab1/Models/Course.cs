namespace mvcLab1.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; } 
        public int MinDegree { get; set; }
        public int Hours { get; set; }
        public List<Instractore> Instractores { get; set; }
        public List<CrsResult> CrsResults { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
