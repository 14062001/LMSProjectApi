using LMSProjectApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMSProjectApi.Repository
{
    public interface IManagerRepository
    {
        Task<List<ManagerModel>> GetAllManager();
        Task<ManagerModel> GetManagerById(int managerid);
        Task<ManagerModel> GetManagerByEmpId(int empid);
        Task<int> AddManager(ManagerModel managerRepository);
        Task<int> UpdateManager(int managerid, ManagerModel managermodel);
        Task<int> DeleteManager(int managerid);
        Task<int> Login(string Email_Address, string Password);
    }
}
