using LMSProjectApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMSProjectApi.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetAllEmployee();
        Task<EmployeeModel> GetEmployeeById(int empid);
        Task<EmployeeModel> GetEmployeeByUsername(string email);
        Task<int> AddEmployee(EmployeeModel employeeModels);
        Task<int> UpdateEmployee(int empid, EmployeeModel employeeModels);
        Task<int> DeleteEmployee(int empid);
        Task<EmployeeModel> Login(string Email_Address, string Password);

    }
}
