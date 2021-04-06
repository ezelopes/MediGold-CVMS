using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medigold_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("ping")]
        public IActionResult getPing(string ping) {
            if (string.IsNullOrWhiteSpace(ping)) return StatusCode(400, "No param");
            if (ping.ToLower() == "ping") return StatusCode(200, "Pong");
            return StatusCode(400, "nope");
        }
    }
}
