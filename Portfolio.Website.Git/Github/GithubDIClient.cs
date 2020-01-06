using Microsoft.Extensions.Options;
using Octokit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Website.Git
{
    internal class GithubDIClient : GitHubClient
    {
        private readonly IOptions<GithubOptions> options;

        public GithubDIClient(IOptions<GithubOptions> options) : base(new ProductHeaderValue(options.Value.AppName))
        {
            this.options = options;
        }
    }
}
