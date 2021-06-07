using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using server.Enums;
using server.Helper;
using server.Models;
using server.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repository
{
    public class EmployeeClaimRepository : IEmployeeClaimRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EmployeeClaimRepository(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            this.appDbContext = appDbContext;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<EmployeeClaim> AddEmployeeClaim(EmployeeClaimViewModel model)
        {
            try
            {
                EmployeeClaim employeeClaim = new EmployeeClaim
                {
                    Comment = model.Comment,
                    EmployeeId = (int)model.EmployeeId,
                    File = !string.IsNullOrEmpty(model.File)? FileUploader.Upload(model.File, model.FileName, webHostEnvironment): null,
                    SubscriptionId = model.SubscriptionId,
                    Status = (byte)EmployeeClaimStatus.Submitted
                };
                appDbContext.EmployeeClaims.Add(employeeClaim);
                await appDbContext.SaveChangesAsync();
                return employeeClaim;
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public async Task<List<EmployeeClaim>> GetEmployeeClaims()
        {
            return await appDbContext.EmployeeClaims.Include(e => e.Employee).ToListAsync();
        }

        public async Task<EmployeeClaim> UpdateEmployeeClaim(EmployeeClaimViewModel model)
        {
            try
            {
                EmployeeClaim employeeClaim = await appDbContext.EmployeeClaims.Include(e => e.Employee)
                    .FirstOrDefaultAsync(e => e.Id == model.Id);
                employeeClaim.Status = (byte)model.Status;
                appDbContext.EmployeeClaims.Update(employeeClaim);
                await appDbContext.SaveChangesAsync();
                return employeeClaim;
            }
            catch(Exception e)
            {

            }
            return null;
        }
    }
}
