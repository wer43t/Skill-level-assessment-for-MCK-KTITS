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
    public class InstitutionsController : Controller
    {
        Core core = new Core();

        private readonly ILogger<InstitutionsController> _logger;

        public InstitutionsController(ILogger<InstitutionsController> logger)
        {
            _logger = logger;
        }

        // GET: api/<InstitutionsController>
        [HttpGet]
        public IEnumerable<Institution> Get()
        {
            return core.GetInstitutions().ToArray();
        }
    }
}
