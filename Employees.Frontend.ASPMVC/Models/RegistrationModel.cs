using System.ComponentModel.DataAnnotations;

namespace Employees.Frontend.ASPMVC.Models
{
    public class RegistrationModel
    {
        [Required]
        [MinLength(4,ErrorMessage = "Логин должен быть не короче 4 символов")]
        [MaxLength(12, ErrorMessage = "Логин должен быть не длиннее 12 символов")]
        public string Login { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Логин должен быть не короче 6 символов")]
        [MaxLength(24, ErrorMessage = "Логин должен быть не длиннее 24 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
