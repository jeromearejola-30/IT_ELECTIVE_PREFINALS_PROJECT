using System.ComponentModel.DataAnnotations;

namespace PREFINALS_PROJECT.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
