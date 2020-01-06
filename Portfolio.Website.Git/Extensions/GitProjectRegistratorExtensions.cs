using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Octokit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Website.Git
{
    public static class GitProjectRegistratorExtensions
    {
        public static void AddGitProvider(this IServiceCollection source, IConfiguration configuration)
        {
            source.Configure<GithubOptions>(configuration.GetSection("Github"));

            source.AddScoped<IGitProjectProvider, GitProjectProvider>();
            source.AddSingleton<IGitHubClient, GithubDIClient>();
        }
    }
}
