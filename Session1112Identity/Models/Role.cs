using System.ComponentModel.DataAnnotations;

namespace Session1112Identity.Models
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
    }
}
