using LMSProjectApi.Models;
using LMSProjectApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LMSProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerRepository managerRepository;
        public ManagerController(IManagerRepository managerRepository)
        {
            this.managerRepository = managerRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllManager()
        {
            var managers = await managerRepository.GetAllManager();
            return Ok(managers);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> SearchById(int id)
        {
            var manager = await managerRepository.GetManagerById(id);
            return Ok(manager);

        }
        [HttpGet("manager/{empid}")]
        public async Task<IActionResult> SearchByEmpId(int empid)
        {
            var manager = await managerRepository.GetManagerByEmpId(empid);
            return Ok(manager);

        }
        [HttpPost]
        public async Task<IActionResult> AddManager(ManagerModel managerModel)
        {
            var managers = await managerRepository.AddManager
                (new ManagerModel
                {
                    Manager_Name = managerModel.Manager_Name,
                    Manager_Address = managerModel.Manager_Address,
                    Manager_Email = managerModel.Manager_Email,
                    Manager_Mobileno = managerModel.Manager_Mobileno,
                    Manager_Password = managerModel.Manager_Password,
                    Manager_Repassword = managerModel.Manager_Repassword
                });
            return Ok(managers);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateManager(int id, ManagerModel managerModel)
        {
            var managers = await managerRepository.UpdateManager(id, managerModel);
            return Ok(managers);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            var managers = await managerRepository.DeleteManager(id);
            return Ok(managers);

        }
        [HttpGet("{email}/{password}")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var managers = await managerRepository.Login(email, password);
            return Ok(managers);

        }
    }
}
