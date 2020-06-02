using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Circle_RestAPI.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        [Route("/")]
        public string rootPath()
        {
            return "Hello World";
        }
    }
}
