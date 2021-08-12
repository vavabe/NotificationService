using Microsoft.AspNetCore.Mvc;
using System;

namespace Notification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello, world";
        }

        [HttpGet]
        [Route("error")]
        public string GetError()
        {
            throw new Exception("Exception");
            return "Hello, world";
        }
    }
}
