using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Octokit;
using Portfolio.Website.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Website.Git
{
    public interface IGitProjectProvider
    {
        Task<IEnumerable<GitProject>> GetGitProjectsAsync();
    }

    public class GitProjectProvider : IGitProjectProvider
    {
        private const string PortfolioInfoDirectory = ".portfolio";
        private const string ManifestPath = PortfolioInfoDirectory + "/Manifest.json";

        private readonly IGitHubClient gitHubClient;
        private readonly IMemoryCache memoryCache;
        private readonly IOptions<GithubOptions> options;
        
        public GitProjectProvider(IGitHubClient gitHubClient, 
            IMemoryCache memoryCache,
            IOptions<GithubOptions> options)
        {
            this.gitHubClient = gitHubClient;
            this.memoryCache = memoryCache;
            this.options = options;
        }

        public async Task<IEnumerable<GitProject>> GetGitProjectsAsync()
        {
            return await memoryCache.GetOrCreateAsync(CacheKeys.ProjectsKey, async (entry) =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                var repositories = (await gitHubClient.Repository.GetAllForUser(options.Value.GithubName));

                ICollection<GitProject> projects = new List<GitProject>();

                foreach (var repo in repositories)
                    try
                    {
                        var files = await gitHubClient.Repository.Content.GetAllDownloadedContents(repo.Id, PortfolioInfoDirectory);

                        var manifest = files.SingleOrDefault(c => c.Path == ManifestPath);
                        if (manifest == null)
                            continue;

                        var value = JsonConvert.DeserializeObject<PortfolioRepositoryManifest>(manifest.Content);

                        var gitProject = new GitProjectBuilder()
                        .WithRepositoryUrl(repo.GitUrl)
                        .WithName(repo.Name)
                        .WithDescription(value.Description ?? repo.Description ?? options.Value.DefaultDescription)
                        .WithFiles(value, files)
                        .Result;

                        if (string.IsNullOrEmpty(gitProject.BannerUrl))
                            gitProject.BannerUrl = options.Value.DefaultBannerUrl;

                        projects.Add(gitProject);
                    }
                    catch (NotFoundException) { }

                return projects;

            });
        }
    }
}
