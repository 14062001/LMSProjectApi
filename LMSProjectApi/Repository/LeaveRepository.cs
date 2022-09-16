using LMSProjectApi.DBConnect;
using LMSProjectApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSProjectApi.Repository
{
    public class LeaveRepository:ILeaveRepository
    {
        private readonly LMS_DataContext lMS_DataContext;
        public LeaveRepository(LMS_DataContext lms_DataContext)
        {
            this.lMS_DataContext = lms_DataContext;
        }

        public async Task<int> ApplyLeave(LeaveModel l)
        {
            lMS_DataContext.Leave.Add(new LeaveModel
            { NoOfDays=l.NoOfDays,Start_date=l.Start_date,End_date=l.End_date,Applied_On=l.Applied_On,
            Leave_Type=l.Leave_Type,Status=l.Status,Reason=l.Reason,Manager_Comment=l.Manager_Comment,
              Emp_id=l.Emp_id,Manager_id=l.Manager_id});
            await lMS_DataContext.SaveChangesAsync();
            return l.Leave_Id;
        }

        public async Task<List<LeaveModel>> GetAllLeave()
        {
            var ar = lMS_DataContext.Leave.ToListAsync();
            return await ar;
        }
        public async Task<List<LeaveModel>> GetAllLeaveByEmpId(int empid)
        {
            var ar = lMS_DataContext.Leave.Where(x => x.Emp_id == empid).ToListAsync();
            return await ar;
        }
        public async Task<List<LeaveModel>> PendingLeaves(int id)
        {
            var ar = lMS_DataContext.Leave.Where(x => x.Manager_id == id && x.Status == "Pending").ToListAsync();
            return await ar;
        }


        public Task<List<LeaveModel>> PendingLeaves()
        {
            throw new System.NotImplementedException();
        }
    }
}
