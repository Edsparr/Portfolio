using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Website.Common
{
    public class GitProject
    {
        public string RepositoryUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string BannerUrl { get; set; }
    }
}
