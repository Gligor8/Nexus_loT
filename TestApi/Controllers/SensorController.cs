using Microsoft.AspNetCore.Mvc;
using System;

namespace TestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        [HttpGet("GetPlainValue")]
        public double GetPlainValue()
        {
            return GetRandomValue();
        }

        [HttpGet("GetJsonValue")]
        public JsonResult GetJsonValue()
        {
            return new JsonResult(new { temperature = GetRandomValue() });
        }

        [HttpGet("GetJsonComplexValue")]
        public JsonResult GetJsonComplexValue()
        {
            return new JsonResult(new { temperature = GetRandomValue(), humidity = GetRandomValue(), });
        }

        private static double GetRandomValue()
        {
            var randomNumber = new Random().NextDouble() * 50;
            return Math.Round(randomNumber, 1);
        }
    }
}
