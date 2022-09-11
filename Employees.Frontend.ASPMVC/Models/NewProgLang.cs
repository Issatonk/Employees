using System.ComponentModel.DataAnnotations;

namespace Employees.Frontend.ASPMVC.Models
{
    public class NewProgLang
    {
        [Required]
        public string Name { get; set; }
    }
}
