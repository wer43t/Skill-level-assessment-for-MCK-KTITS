using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkillAssesmentCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillLevelAssismentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        Core core = new Core();

        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ILogger<CategoriesController> logger)
        {
            _logger = logger;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<Categories> Get()
        {
            return core.GetCategories().ToArray();
        }
    }
}
