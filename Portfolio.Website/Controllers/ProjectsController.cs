using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Website.Api;
using Portfolio.Website.TypeConverters;

namespace Portfolio.Website
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly PortfolioProjectTypeConverter converter;
        private readonly IProjectFetcherService fetcherService;
        public ProjectsController(PortfolioProjectTypeConverter converter, IProjectFetcherService fetcherService)
        {
            this.fetcherService = fetcherService;
            this.converter = converter;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<PortfolioProject>> GetProjectsAsync()
        {
            return (await fetcherService.GetRepositoriesAsync());
        }

        [HttpGet("{projectName}")]
        public async Task<PortfolioProject> GetProjectAsync([FromRoute] string projectName)
        {
            var repository = await fetcherService.GetRepositoryAsync(projectName);

            return repository;
        }
    }
}
