using Employees.Core.Helpers;
using Employees.DataAccess.MSSQL.Entities;
using System;
using System.Collections.Generic;

namespace Employees.DataAccess.MSSQL
{
    public class DataGenerator
    {
        private readonly EmployeesContext _context;
        private List<User> _users;
        private List<Department> _departments;
        private List<PositionInCompany> _proglang;
        private List<Employee> _employees;

        private readonly List<string> names = new List<string>()
            {
                "Brandon", "Ronald", "Charles", "Stephen", "Diane",
                "Kelly", "Marie", "Robert", "Nancy", "Dorothy",
                "Rosemary", "Arthur", "Paula", "Richard", "Joan",
                "Lawrence", "Michael", "Carmen", "Peter", "John",
                "Russell", "Teresa", "Brenda", "Pedro", "Rendy",
                "Warren", "George", "Mary", "Nellie", "Steven",
                "David", "Virginia", "Irene", "Angela", "Edvard"
            };

        private readonly List<string> surnames = new List<string>()
            {
                "Miles", "Soto", "Jones", "Williams", "Warren",
                "Rhodes", "Brows", "Woods", "Lopez", "Robinson",
                "Moore", "Payne", "Chavez", "Ramos", "Coleman",
                "Admas", "Terry", "Allen", "Potter", "Watson",
                "Foster", "Miller", "Green", "Barton", "Smith",
                "Gray", "Hudson", "Cortez", "Holmes", "Turner",
                "Blake", "Olson", "Park", "Perry", "Stewart"
            };
        public DataGenerator(EmployeesContext context)
        {

            _context = context;
            var salt = CryptoHelper.GetSalt();
            _users = new List<User>()
            {
                new User
                {
                    Login = "Admin",
                    Role = "Admin",
                    Salt = salt,
                    Password = CryptoHelper.GetHash("b1209824109", salt)
                }
            };
            _departments = new List<Department>()
            {
                new Department
                {
                    Floor = 2,
                    Name = "Dep1"
                },
                new Department
                {
                    Floor = 1,
                    Name = "Dep2"
                },
                new Department
                {
                    Floor = 3,
                    Name = "Dep3"
                },
                new Department
                {
                    Floor = 5,
                    Name = "Dep4"
                },
                new Department
                {
                    Floor = 5,
                    Name = "Dep5"
                },
                new Department
                {
                    Floor = 3,
                    Name = "Dep6"
                },
                new Department
                {
                    Floor = 1,
                    Name = "Dep7"
                },
                new Department
                {
                    Floor = 8,
                    Name = "Dep8"
                },
                new Department
                {
                    Floor = 4,
                    Name = "Dep9"
                },
                new Department
                {
                    Floor = 5,
                    Name = "Dep10"
                }
            };
            _proglang = new List<PositionInCompany>()
            {
                new PositionInCompany
                {
                    Name = "C#"
                },
                new PositionInCompany
                {
                    Name = "Java"
                },
                new PositionInCompany
                {
                    Name = "JavaScript"
                },
                new PositionInCompany
                {
                    Name = "Python"
                },
                new PositionInCompany
                {
                    Name = "SQL"
                },
                new PositionInCompany
                {
                    Name = "C++"
                },
                new PositionInCompany
                {
                    Name = "Kotlin"
                },
                new PositionInCompany
                {
                    Name = "PHP"
                }
            };
            _employees = new List<Employee>();

            DateTime start = new DateTime(1970, 1, 1);
            int range = (new DateTime(2004, 1, 1) - start).Days;

            Random rnd = new Random();
            for (int i = 0; i < _departments.Count; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    var birthday = start.AddDays(rnd.Next(range));

                    _employees.Add(new Employee
                    {
                        Name = names[rnd.Next(names.Count)],
                        Surname = surnames[rnd.Next(surnames.Count)],
                        Birthday = birthday,
                        Gender = (Gender)rnd.Next(0, 2),
                        Department = _departments[rnd.Next(_departments.Count)],
                        Position = _proglang[rnd.Next(_proglang.Count)]
                    });
                }
            }
            _context.Users.AddRange(_users);
            _context.Employees.AddRange(_employees);
            _context.SaveChanges();
        }


    }
}
