using LMSProjectApi.Models;
using LMSProjectApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LMSProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : Controller
    {
        private readonly ILeaveRepository leaveRepository;
        public LeaveController(ILeaveRepository leaveRepository)
        {
            this.leaveRepository = leaveRepository;
        }
        [HttpGet]
        [Route("displayleaves")]
        public async Task<IActionResult> GetAllLeave()
        {
            var employeeleaves = await leaveRepository.GetAllLeave();
            return Ok(employeeleaves);

        }
        [HttpGet("{empid}")]
        public async Task<IActionResult> GetAllLeaveByEmpId(int empid)
        {
            var employees = await leaveRepository.GetAllLeaveByEmpId(empid);
            return Ok(employees);

        }
        [HttpPost]
        [Route("ApplyLeave")]
        public async Task<IActionResult> AddLeave(LeaveModel leaveModesls)
        {
            var leaves = await leaveRepository.ApplyLeave
                (new LeaveModel
                {
                    NoOfDays=leaveModesls.NoOfDays,
                    Start_date=leaveModesls.Start_date,
                    End_date=leaveModesls.End_date,
                    Leave_Type=leaveModesls.Leave_Type,
                    Status=leaveModesls.Status,
                    Reason=leaveModesls.Reason,
                    Applied_On=DateTime.Now,
                    Manager_id=leaveModesls.Manager_id,
                    Emp_id=leaveModesls.Emp_id
                });
            return Ok(leaves);

        }
    }
}
