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
    public class PostsController : Controller
    {
        Core core = new Core();

        private readonly ILogger<PostsController> _logger;

        public PostsController(ILogger<PostsController> logger)
        {
            _logger = logger;
        }

        // GET: api/<PostsController>
        [HttpGet]
        public IEnumerable<Posts> Get()
        {
            return core.GetPosts().ToArray();
        }
    }
}
