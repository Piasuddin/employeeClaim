using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Repository;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepositiry employeeRepositiry;

        public EmployeeController(IEmployeeRepositiry employeeRepositiry)
        {
            this.employeeRepositiry = employeeRepositiry;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Employee>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await employeeRepositiry.GetEmployees());
        }
    }
}