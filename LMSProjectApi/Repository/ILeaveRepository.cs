using LMSProjectApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMSProjectApi.Repository
{
    public interface ILeaveRepository
    {
        Task<List<LeaveModel>> GetAllLeave();
        Task<List<LeaveModel>> GetAllLeaveByEmpId(int empid);
        Task<int> ApplyLeave(LeaveModel l);
        Task<List<LeaveModel>> PendingLeaves();
    }
}
