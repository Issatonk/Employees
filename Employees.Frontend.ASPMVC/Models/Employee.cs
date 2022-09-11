using System;

namespace Employees.Frontend.ASPMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

        public Department Department { get; set; }

        public ProgLang ProgLang { get; set; }

        public int Age 
        { 
            get
            {
                var age = DateTime.Now.Year - Birthday.Year;
                if (DateTime.Now.DayOfYear < Birthday.DayOfYear)
                    age--;
                return age;
            } 
        }
    
    }
    public enum Gender
    {
        male,
        female
    }
}
