using LMSProjectApi.DBConnect;
using LMSProjectApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSProjectApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly LMS_DataContext lMS_DataContext;

        public EmployeeRepository(LMS_DataContext lms_DataContext)
        {
            this.lMS_DataContext = lms_DataContext;
        }
        public async Task<int> AddEmployee(EmployeeModel employeeModels)
        {
            lMS_DataContext.Employees.Add(new EmployeeModel {
                Emp_Name = employeeModels.Emp_Name,
                Emp_Address = employeeModels.Emp_Address,
                Emp_Email = employeeModels.Emp_Email,
                Emp_Mobileno = employeeModels.Emp_Mobileno,
                Emp_Doj = employeeModels.Emp_Doj,
                Emp_Dept = employeeModels.Emp_Dept,
                Designation=employeeModels.Designation,
                Avail_Leave_Bal = employeeModels.Avail_Leave_Bal,
                Emp_Password = employeeModels.Emp_Password,
                Emp_Repassword = employeeModels.Emp_Repassword
            });
            await lMS_DataContext.SaveChangesAsync();
            return employeeModels.Emp_Id;
        }

        public async Task<int> DeleteEmployee(int empid)
        {
            var ar = await lMS_DataContext.Employees.Where(x => x.Emp_Id == empid).FirstOrDefaultAsync();
            if (ar != null)
            {
                lMS_DataContext.Employees.Remove(ar);
                await lMS_DataContext.SaveChangesAsync();
            }
            return empid;
        }

        public async Task<List<EmployeeModel>> GetAllEmployee()
        {
            var ar = lMS_DataContext.Employees.ToListAsync();
            return await ar;
        }

        public async Task<EmployeeModel> GetEmployeeById(int empid)
        {
            var ar = await lMS_DataContext.Employees.Where(x => x.Emp_Id == empid).FirstOrDefaultAsync();
            return ar;
        }

        public async Task<EmployeeModel> GetEmployeeByUsername(string email)
        {
            var ar = await lMS_DataContext.Employees.Where(x => x.Emp_Email == email).FirstOrDefaultAsync();
            return ar;
        }

        public async Task<EmployeeModel> Login(string Email_Address, string Password)
        {
            var ar = await lMS_DataContext.Employees.Where(x => x.Emp_Email == Email_Address 
            && x.Emp_Password == Password).FirstOrDefaultAsync();
            if (ar != null)
            {
                return ar;
            }
            return null;
        }

        public async Task<int> UpdateEmployee(int empid, EmployeeModel employeeModels)
        {
            var ar = await lMS_DataContext.Employees.Where(x => x.Emp_Id == empid).FirstOrDefaultAsync();
            if (ar != null)
            {
                ar.Emp_Name = employeeModels.Emp_Name;
                ar.Emp_Dept = employeeModels.Emp_Dept;
                await lMS_DataContext.SaveChangesAsync();

            }
            return empid;
        }
    }
}
