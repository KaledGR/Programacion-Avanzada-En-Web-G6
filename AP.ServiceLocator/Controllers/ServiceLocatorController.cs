
using AP.Models.DTOs;
using AP.ServiceLocator.Services;
using AP.ServiceLocator.Helper;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AP.ServiceLocator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceLocatorController : ControllerBase
    {


        
        private readonly ISourceItemService _sourceItemService;
        private readonly ITaskService _taskService;
        private readonly ISourceService _sourceService;

        public ServiceLocatorController(ISourceItemService sourceItemService, ISourceService sourceService, ITaskService taskService)
        { 
          
            _sourceItemService = sourceItemService;
            _taskService = taskService;
            _sourceService = sourceService;
          
        }

        // GET api/<ServiceLocatorController>/5


      

        [HttpGet("source")]
        public async Task<IEnumerable<SourceDTO>> GetRole()
        {
            return await _sourceService.GetDataAsync();
        }

        [HttpGet("task")]
        public async Task<IEnumerable<TaskDTO>> GetTask()
        {
            return await _taskService.GetDataAsync();
        }

        [HttpGet("sourceItem")]
        public async Task<IEnumerable<SourceItemDTO>> GetUser()
        {
            return await _sourceItemService.GetDataAsync();
        }

       



    }
}
