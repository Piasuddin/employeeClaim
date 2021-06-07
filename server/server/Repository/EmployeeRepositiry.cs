using Microsoft.EntityFrameworkCore;
using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repository
{
    public class EmployeeRepositiry : IEmployeeRepositiry
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepositiry(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            return await appDbContext.Employees.ToListAsync();
        }
    }
}
