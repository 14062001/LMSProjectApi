using LMSProjectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LMSProjectApi.DBConnect
{
    public class LMS_DataContext:DbContext
    {
        public LMS_DataContext(DbContextOptions<LMS_DataContext>options) : base(options)
        {
             
        }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<ManagerModel> Managers { get; set; }
        public DbSet<LeaveModel> Leave { get; set; }
    }
}
