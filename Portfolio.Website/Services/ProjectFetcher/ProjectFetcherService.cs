using Microsoft.Extensions.Caching.Memory;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Website
{
    public interface IProjectFetcherService
    {
        Task<Github>
    }

    public class ProjectFetcherService : IProjectFetcherService
    {
        private readonly MemoryCache cache;
        private readonly IGitHubClient client;

        public ProjectFetcherService(IGitHubClient client, MemoryCache cache)
        {
            this.client = client;
            this.cache = cache;

            client.Repository.GetAllForUser("")
        }
    }
}
