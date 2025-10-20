using System.ComponentModel.DataAnnotations;

namespace mvcLab1.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                //ITIDBContext context = new ITIDBContext();
                ITIDBContext context = validationContext.GetRequiredService<ITIDBContext>();
                CourseDataViewModel validateCourse = validationContext.ObjectInstance as CourseDataViewModel;
                Course course = context.Courses
                    .FirstOrDefault(c => c.Name == value.ToString() && c.DepartmentId == validateCourse.DepartmentId);
                if (course != null )
                {
                    return new ValidationResult("Course name must be unique");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Course name is required");

        }
    }
}
