namespace Employees.Frontend.ASPMVC.Models
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class Token
    {
        public string access_token { get; set; }
        public string username { get; set; }
        public string role { get; set; }

        public int? departmentId { get; set; }
    }
}
