using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Website
{
    internal static class CacheKeys
    {
        public static string ProjectKey { get; } = "GithubProject_{0}";
        public static string ProjectListKey { get; } = "GithubProjectList";
    }
}