
namespace mvcLab1.ViewModel
{
    public class InstructorWithDepartmentListWithCourseListViewModel
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string imageUrl { get; set; }

        public IFormFile Image { get; set; }
        public string? Address { get; set; }
        public int DepartmentId { get; set; }

        public int CourseId { get; set; }
        public List<Department> DepartmentList { get; set; }
        public List<Course> CourseList { get; set; }
    }
}
