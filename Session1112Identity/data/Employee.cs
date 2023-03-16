using System.ComponentModel.DataAnnotations.Schema;

namespace Session1112Identity.data
{
    [Table("Employees")]
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
