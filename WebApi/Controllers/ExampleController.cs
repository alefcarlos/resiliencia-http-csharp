using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        // GET api/example//timeout/25
        [HttpGet("timeout/{timeout}")]
        public async Task<IActionResult> GetTimeOut(int timeout, CancellationToken cancelationToken)
        {
            await Task.Delay(TimeSpan.FromSeconds(timeout), cancelationToken);

            return Ok();
        }

        // GET api/example/error/500
        [HttpGet("error/{code}")]
        public IActionResult GetError(int code)
        {
            return new ObjectResult("error")
            {
                StatusCode = code
            };
        }


        // GET api/example/success
        [HttpGet("success")]
        public IActionResult GetSuccess()
        {
            return Ok();
        }
    }
}
