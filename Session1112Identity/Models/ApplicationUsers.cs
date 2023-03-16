using Microsoft.AspNetCore.Identity;

namespace Session1112Identity.Models
{
    public class ApplicationUsers:IdentityUser
    {
        public string Name { get; set; }
        public string Gender { get; set; }
    }
}
