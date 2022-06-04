using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkillAssesmentCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace SkillLevelAssismentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        Core core = new Core();

        private readonly ILogger<TeacherController> _logger;

        public TeacherController(ILogger<TeacherController> logger)
        {
            _logger = logger;
        }


        // GET: api/<TeacherController>
        [HttpGet]
        public IEnumerable<Teachers> Get()
        {
            var tempUsersData = core.GetTeachers();

            return tempUsersData; 
        }
    }
}
