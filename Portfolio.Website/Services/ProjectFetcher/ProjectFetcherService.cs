using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Octokit;
using Portfolio.Website.Api;
using Portfolio.Website.Settings;
using Portfolio.Website.TypeConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Website
{
    public interface IProjectFetcherService
    {
        Task<PortfolioProject> GetRepositoryAsync(string name);
        Task<IEnumerable<PortfolioProject>> GetRepositoriesAsync();

        Task<Dictionary<string, byte[]>> GetDisplayFilesAsync(string name);
    }

    public class ProjectFetcherService : IProjectFetcherService
    {
        private readonly IMemoryCache cache;
        private readonly IGitHubClient client;
        private readonly IOptions<GithubUserSettings> userSettings;
        private readonly PortfolioProjectTypeConverter projectTypeConverter;
        public ProjectFetcherService(PortfolioProjectTypeConverter projectTypeConverter, IOptions<GithubUserSettings> userSettings, IGitHubClient client, IMemoryCache cache)
        {
            this.projectTypeConverter = projectTypeConverter;
            this.client = client;
            this.cache = cache;
            this.userSettings = userSettings;

        }

        public async Task<PortfolioProject> GetRepositoryAsync(string name)
        {
            return await cache.GetOrCreateAsync(string.Format(CacheKeys.ProjectKey, name), async (entry) =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15);
    
                var repository = await client.Repository.Get(userSettings.Value.Username, name);

                return await ConvertToProjectAsync(repository);
            });
        }

        public async Task<IEnumerable<PortfolioProject>> GetRepositoriesAsync()
        {
            return await cache.GetOrCreateAsync<IEnumerable<PortfolioProject>>(CacheKeys.ProjectListKey, async (entry) =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15);

                var repos = await client.Repository.GetAllForUser(userSettings.Value.Username);
                var convertedReposTasks = repos.Select(async c => await ConvertToProjectAsync(c));

                var convertedRepos = await Task.WhenAll(convertedReposTasks);

                return convertedRepos;
            });
        }

        public async Task<Dictionary<string, byte[]>> GetDisplayFilesAsync(string name)
        {
            Dictionary<string, byte[]> content = new Dictionary<string, byte[]>();
            try
            {
                content = (await client.Repository.Content.GetAllContents(userSettings.Value.Username, name, "DisplayFiles"))
                    .Where(c => c.Type == ContentType.File)
                .ToDictionary(key =>
                {
                    return key.Name;
                }, (element) =>
                {

                    return new byte[0];
                });
            }
            catch (NotFoundException) { }

            try
            {
                var readMe = await client.Repository.Content.GetReadme(userSettings.Value.Username, name);

                content.Add(readMe.Name, Encoding.ASCII.GetBytes(readMe.Content));
            }
            catch (NotFoundException) { }

            return content;
        }

        private async Task<PortfolioProject> ConvertToProjectAsync(Repository repository)
        {
            var portfolioProject = (PortfolioProject)projectTypeConverter.ConvertTo(repository, typeof(PortfolioProject));
            portfolioProject.DisplayFiles = await GetDisplayFilesAsync(repository.Name);
           

            return portfolioProject;

        }
    }
}
