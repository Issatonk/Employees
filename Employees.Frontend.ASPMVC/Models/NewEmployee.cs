using System;
using System.ComponentModel.DataAnnotations;

namespace Employees.Frontend.ASPMVC.Models
{
    public class NewEmployee
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int ProgLangId { get; set; }
    }
}
