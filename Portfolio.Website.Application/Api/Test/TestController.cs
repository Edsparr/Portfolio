using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Website.Application.Api.Test
{
    [Route("Api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task Test()
        {

        }
    }
}
