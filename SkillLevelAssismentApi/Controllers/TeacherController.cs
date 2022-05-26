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


        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return core.GetUsers().ToArray();
        }
        /// <param name = "id" > Here is the description for ID.</param>
        /// <param name = "id" > Here is the description for ID.</param>
        /// <param name = "id" > Here is the description for ID.</param>
        /// <param name = "id" > Here is the description for ID.</param>
        /// <param name = "id" > Here is the description for ID.</param>
        [ProducesResponseType(typeof(Users), (int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromRoute] int id)
        {

            //core.AddUsers();
            return Ok(new Users());
        }
    }
}
