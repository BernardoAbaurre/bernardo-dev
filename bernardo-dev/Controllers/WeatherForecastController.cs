using bernardo_dev.Data;
using Microsoft.AspNetCore.Mvc;

namespace bernardo_dev.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly BernardoDevDbContext dbContext;

        public WeatherForecastController(BernardoDevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var weather = dbContext.WeatherTypes.ToList();

            return Ok(weather);
        }
    }
}
