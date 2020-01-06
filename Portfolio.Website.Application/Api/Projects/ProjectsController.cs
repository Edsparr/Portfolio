using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Website.Common;
using Portfolio.Website.Git;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Website.Application.Api
{  
    [Route("Api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IGitProjectProvider gitProjectProvider;

        public ProjectsController(IGitProjectProvider gitProjectProvider)
        {
            this.gitProjectProvider = gitProjectProvider;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GitProject>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProjectsAsync()
        {
            return Ok(await gitProjectProvider.GetGitProjectsAsync());
        }

    }
}
