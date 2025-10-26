using System.ComponentModel.DataAnnotations;

namespace mvcLab1.ViewModel
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string? address { get; set; }

    }
}
