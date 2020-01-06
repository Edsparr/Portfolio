using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Website.Common
{
    public class GitProjectBuilder : BuilderBase<GitProject>
    {
        public GitProjectBuilder() : base() { }

        public GitProjectBuilder WithRepositoryUrl(string repositoryUrl)
        {
            Result.RepositoryUrl = repositoryUrl;
            return this;
        }

        public GitProjectBuilder WithName(string name)
        {
            Result.Name = name;
            return this;
        }

        public GitProjectBuilder WithDescription(string description)
        {
            Result.Description = description;
            return this;
        }



        public GitProjectBuilder WithBannerUrl(string bannerUrl)
        {
            Result.BannerUrl = bannerUrl;
            return this;
        }
    }
}
