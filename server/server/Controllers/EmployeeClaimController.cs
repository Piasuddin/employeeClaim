using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Repository;
using server.ViewModels;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeClaimController : ControllerBase
    {
        private readonly IEmployeeClaimRepository employeeClaimRepository;

        public EmployeeClaimController(IEmployeeClaimRepository employeeClaimRepository)
        {
            this.employeeClaimRepository = employeeClaimRepository;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EmployeeClaim>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await employeeClaimRepository.GetEmployeeClaims());
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EmployeeClaim>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(EmployeeClaimViewModel employeeClaim)
        {
            var result = await employeeClaimRepository.UpdateEmployeeClaim(employeeClaim);
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EmployeeClaim>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(EmployeeClaimViewModel employeeClaim)
        {
            var result = await employeeClaimRepository.AddEmployeeClaim(employeeClaim);
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
    }
}