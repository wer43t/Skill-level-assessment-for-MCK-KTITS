using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkillAssesmentCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillLevelAssismentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : Controller
    {
        Core core = new Core();

        private readonly ILogger<DistrictsController> _logger;

        public DistrictsController(ILogger<DistrictsController> logger)
        {
            _logger = logger;
        }

        // GET: api/<DistrictsController>
        [HttpGet]
        public IEnumerable<Discticts> Get()
        {
            return core.GetDiscticts().ToArray();
        }
    }
}
