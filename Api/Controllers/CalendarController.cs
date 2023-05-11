using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    [Route("Api/Calendar")]
    public class CalendarController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Boolean> GetHolidays()
        {            
            return Ok(null);
        }
    }
}
