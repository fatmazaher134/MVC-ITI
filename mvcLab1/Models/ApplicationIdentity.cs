using Microsoft.AspNetCore.Identity;

namespace mvcLab1.Models
{
    public class ApplicationIdentity : IdentityUser
    {
        public string? address  { get; set; }
    }
}
