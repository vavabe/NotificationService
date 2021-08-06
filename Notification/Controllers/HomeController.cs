using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
