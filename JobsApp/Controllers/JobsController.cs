using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsApp.Core.Interfaces;
using JobsApp.Core.Interfaces.Repositories;
using JobsApp.Core.Models.FilterModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JobsApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly ILogger<JobsController> _logger;
        private readonly IRepositoryManager _repoManager;

        public JobsController(IRepositoryManager repoManager,
            ILogger<JobsController> logger)
        {
            _logger = logger;
            _repoManager = repoManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] JobFilterModel filter)
        {
            try
            {
                //TODO : Implement global exception handling
                return Ok(await _repoManager.Jobs.GetJobsAsync(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            //TODO : Implement global exception handling
            try
            {
                return Ok(await _repoManager.Jobs.GetJobAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
