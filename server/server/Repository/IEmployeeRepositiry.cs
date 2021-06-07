using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repository
{
    public interface IEmployeeRepositiry
    {
        Task<List<Employee>> GetEmployees();
    }
}
