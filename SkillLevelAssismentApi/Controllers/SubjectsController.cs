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
    public class SubjectsController : Controller
    {
        Core core = new Core();

        private readonly ILogger<SubjectsController> _logger;

        public SubjectsController(ILogger<SubjectsController> logger)
        {
            _logger = logger;
        }

        // GET: api/<SubjectsController>
        [HttpGet]
        public IEnumerable<Subjects> Get()
        {
            return core.GetSubjects().ToArray();
        }
    }
}
