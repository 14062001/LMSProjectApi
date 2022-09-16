using LMSProjectApi.DBConnect;
using LMSProjectApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSProjectApi.Repository
{
    public class ManagerRepository:IManagerRepository
    {
        private readonly LMS_DataContext lMS_DataContext;
        public ManagerRepository(LMS_DataContext lms_DataContext)
        {
            this.lMS_DataContext = lms_DataContext;
        }

        public async Task<int> AddManager(ManagerModel managerModel)
        {
            lMS_DataContext.Managers.Add(new ManagerModel
            {
             Manager_Name=managerModel.Manager_Name,
             Manager_Address=managerModel.Manager_Address,
             Manager_Email=managerModel.Manager_Email,
             Manager_Mobileno=managerModel.Manager_Mobileno,
             Manager_Password=managerModel.Manager_Password,
             Manager_Repassword=managerModel.Manager_Repassword
            });
            await lMS_DataContext.SaveChangesAsync();
            return managerModel.Manager_Id;
        }

        public async Task<int> DeleteManager(int managerid)
        {
            var ar = await lMS_DataContext.Managers.Where(x => x.Manager_Id == managerid).FirstOrDefaultAsync();
            if (ar != null)
            {
                lMS_DataContext.Managers.Remove(ar);
                await lMS_DataContext.SaveChangesAsync();
            }
            return managerid;
        }
        public async Task<int> Login(string Email_Address, string Password)
        {
            var ar = await lMS_DataContext.Managers.Where(x => x.Manager_Email == Email_Address
            && x.Manager_Password == Password).FirstOrDefaultAsync();
            if (ar != null)
            {
                return 1;
            }
            return 0;
        }

        public async Task<List<ManagerModel>> GetAllManager()
        {
            var ar = lMS_DataContext.Managers.ToListAsync();
            return await ar;
        }

        public async Task<ManagerModel> GetManagerById(int managerid)
        {
            var ar = await lMS_DataContext.Managers.Where(x =>x.Manager_Id == managerid).FirstOrDefaultAsync();
            return ar;
        }
        public async Task<ManagerModel> GetManagerByEmpId(int empid)
        {
            var ar = await lMS_DataContext.Managers.Where(x => x.Emp_id == empid).FirstOrDefaultAsync();
            return ar;
        }

        public async Task<int> UpdateManager(int managerid, ManagerModel managerModel)
        {
            var ar = await lMS_DataContext.Managers.Where(x => x.Manager_Id == managerid).FirstOrDefaultAsync();
            if (ar != null)
            {
                ar.Manager_Name = managerModel.Manager_Name;
                ar.Manager_Mobileno = managerModel.Manager_Mobileno;
                await lMS_DataContext.SaveChangesAsync();

            }
            return managerid;
        }
    }
}
