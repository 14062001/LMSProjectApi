using LMSProjectApi.Models;
using LMSProjectApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LMSProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var employees = await employeeRepository.GetAllEmployee();
            return Ok(employees);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> SearchById(int id)
        {
            var employees = await employeeRepository.GetEmployeeById(id);
            return Ok(employees);

        }
        [HttpGet("empdetails/{email}")]
        public async Task<IActionResult> SearchByEmail(string email)
        {
            var employees = await employeeRepository.GetEmployeeByUsername(email);
            return Ok(employees);

        }
        [HttpGet("{email}/{password}")]
        public async Task<IActionResult> Login(string email,string password)
        {
            var employees = await employeeRepository.Login(email,password);
            return Ok(employees);

        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeModel employeeModels)
        {
            var employees = await employeeRepository.AddEmployee
                (new EmployeeModel {Emp_Name=employeeModels.Emp_Name,Emp_Address=employeeModels.Emp_Address,
                  Emp_Email=employeeModels.Emp_Email,Emp_Mobileno=employeeModels.Emp_Mobileno,
                    Emp_Doj=employeeModels.Emp_Doj,Emp_Dept=employeeModels.Emp_Dept,
                   Avail_Leave_Bal=employeeModels.Avail_Leave_Bal,
                   Designation=employeeModels.Designation,
                    Emp_Password=employeeModels.Emp_Password,Emp_Repassword=employeeModels.Emp_Repassword});
            return Ok(employees);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeModel employeeModels)
        {
            var employees = await employeeRepository.UpdateEmployee(id, employeeModels);
            return Ok(employees);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employees = await employeeRepository.DeleteEmployee(id);
            return Ok(employees);

        }
    }
}
