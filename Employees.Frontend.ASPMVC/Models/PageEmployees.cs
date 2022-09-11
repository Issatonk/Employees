using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Employees.Frontend.ASPMVC.Models
{
    public class PageEmployees
    {
        public IEnumerable<Employee> Employees { get; set; }


        [Required]       
        public int Pages { get; set; }

        [Required]
        public int CurrentPage { get; set; }

    }
}
