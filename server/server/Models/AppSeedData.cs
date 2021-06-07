using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public static class AppSeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Employee>().HasData(
                new Employee{ Id = 1, EmployeeName = "Employee 1", Email = "employee1@gmail.com", Mobile = "01874343566" },
                new Employee{ Id = 2, EmployeeName = "Employee 2", Email = "employee2@gmail.com", Mobile = "00943274444" },
                new Employee{ Id = 3, EmployeeName = "Employee 3", Email = "employee3@gmail.com", Mobile = "34894397875" },
                new Employee{ Id = 4, EmployeeName = "Employee 4", Email = "employee4@gmail.com", Mobile = "09089754535" },
                new Employee{ Id = 5, EmployeeName = "Employee 5", Email = "employee5@gmail.com", Mobile = "24827573545" },
                new Employee{ Id = 6, EmployeeName = "Employee 6", Email = "employee6@gmail.com", Mobile = "00727445557" }
                );
        }
    }
}
