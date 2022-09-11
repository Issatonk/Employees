using System.ComponentModel.DataAnnotations;

namespace Employees.Frontend.ASPMVC.Models
{
    public class NewDepartment
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Floor { get; set; }
    }
}
