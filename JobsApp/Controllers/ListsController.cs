using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsApp.Core.Interfaces;
using JobsApp.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JobsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListsController : ControllerBase
    {
        private readonly ILogger<ListsController> _logger;
        private readonly IRepositoryManager _repoManager;

        public ListsController(IRepositoryManager repoManager,
            ILogger<ListsController> logger)
        {
            _logger = logger;
            _repoManager = repoManager;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                //TODO : Implement global exception handling
                return Ok(_repoManager.Categories.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("locations")]
        public async Task<IActionResult> GetAllLocations()
        {
            try
            {
                //TODO : Implement global exception handling
                return Ok(_repoManager.Locations.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}