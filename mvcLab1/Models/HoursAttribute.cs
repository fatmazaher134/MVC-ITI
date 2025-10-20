using System.ComponentModel.DataAnnotations;
namespace mvcLab1.Models
{
    public class HoursAttribute :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int hours = (int)value;
            if (hours !=0)
            {
                
                if (hours !=0 && hours %3 ==0)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Hours must be devisable by 3");
                }
            }
            return new ValidationResult("Hours is required");
        }
    }
}
