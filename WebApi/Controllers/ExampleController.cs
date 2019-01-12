using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private static int returnTimeoutSuccess = 0;
        private static int returnErrorSuccess = 0;

        // GET api/example//timeout/25/complete/3
        [HttpGet("timeout/{timeout}/complete/{complete}")]
        public async Task<IActionResult> GetTimeOut(int timeout, int complete)
        {
            //Precisamos simular que o sistema voltou a funcionar
            returnTimeoutSuccess++;
            if (returnTimeoutSuccess == complete)
            {
                returnTimeoutSuccess = 0;
                return Ok();
            };

            await Task.Delay(TimeSpan.FromSeconds(timeout));

            return Ok();
        }

        // GET api/example/error/500/complete/5
        [HttpGet("error/{code}/complete/{complete}")]
        public async Task<IActionResult> GetError(int code, int complete)
        {
            await Task.Delay(1_000);

            //Precisamos simular que o sistema voltou a funcionar
            returnErrorSuccess++;
            if (returnErrorSuccess == complete)
            {
                returnErrorSuccess = 0;
                return Ok();
            };

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
