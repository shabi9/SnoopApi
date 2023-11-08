using Microsoft.AspNetCore.Mvc;

namespace SnoopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class snoopController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] object payload)
        {
            try
            {
                var headers = Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());
                var response = new { payload, headers };
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                // Log the exception details here as per your logging strategy
                return StatusCode(500, new { message = "An error occurred while processing your request.", exception = ex.Message });
            }
        }
    }
}
