using server.Models;
using server.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repository
{
    public interface IEmployeeClaimRepository
    {
        Task<List<EmployeeClaim>> GetEmployeeClaims();
        Task<EmployeeClaim> AddEmployeeClaim(EmployeeClaimViewModel model);
        Task<EmployeeClaim> UpdateEmployeeClaim(EmployeeClaimViewModel model);
    }
}
