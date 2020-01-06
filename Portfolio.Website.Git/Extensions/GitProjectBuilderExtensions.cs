using Octokit;
using Portfolio.Website.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Website.Git
{
    public static class GitProjectBuilderExtensions
    {
        public static GitProjectBuilder WithFiles(this GitProjectBuilder source, PortfolioRepositoryManifest manifest,  IEnumerable<RepositoryContent> files)
        {
            return source.
                WithBannerUrl(files.SingleOrDefault(c => c.Name == manifest.BannerPath)?.Url ?? source.Result.BannerUrl);
        }
    }
}
