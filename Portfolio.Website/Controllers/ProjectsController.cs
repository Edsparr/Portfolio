using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Website.Api;

namespace Portfolio.Website
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {


        [HttpGet("[action]")]
        public async Task<IEnumerable<PortfolioProject>> ProjectsAsync()
        {

        }
    }
}
