using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace mvcLab1.ViewModel
{
    public class CourseDataViewModel
    {
        [Display(Name = "Course Name")]
        [Unique]
        [MinLength(2, ErrorMessage ="The name length must be more than one char")]
        public string Name { get; set; }
        [Display(Name = "Full mark degree")]
        [Range(50, 100, ErrorMessage ="The Degree must between 50 and 100")]
        public int Degree { get; set; }
        [Display(Name = "Minimum degree to pass")] 
        [Remote(action: "CheckMinDegree", controller: "Course", AdditionalFields = "Degree", ErrorMessage = "Min Degree must be less than Degree")]
        public int MinDegree { get; set; }
        [Hours]
        public int Hours { get; set; }
        [Display(Name = "Department")]

        public int DepartmentId { get; set; }

        public List<Department> departmentList;
    }
}
