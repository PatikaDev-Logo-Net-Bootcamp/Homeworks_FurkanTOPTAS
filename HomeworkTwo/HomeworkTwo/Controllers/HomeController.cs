using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeworkTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/<HomeController>
        [HttpGet]
        public IActionResult Home()
        {
            return Ok();
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login()
        {
            return Ok();
        }
        [HttpPut]
        [Route("Register")]
        public IActionResult Register()
        {
            return Ok();
        }
        [HttpDelete]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("Hidden")]
        public IActionResult Delete()
        {
            return Ok();
        }


    }
}
