﻿using Employees.Core.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Requests
{

    public class CreateEmployeeRequest
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }

        public int DepartmentId { get; set; }

        public int PositionInCompanyId { get; set; }

        public Contacts Contacts { get; set; }


    }
}