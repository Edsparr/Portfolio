using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Website.Api
{
    public class PortfolioProject
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("stars")]
        public int Stars { get; set; }

        [JsonProperty("displayFiles")]
        public Dictionary<string, string> DisplayFiles { get; set; }
    }
}
