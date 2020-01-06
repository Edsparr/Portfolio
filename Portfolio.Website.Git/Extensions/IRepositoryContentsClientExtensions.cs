using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Website.Git
{
    public static class IRepositoryContentsClientExtensions
    {
        public static async Task<RepositoryContent> GetContent(this IRepositoryContentsClient source, long id, string path)
        {
            return (await source.GetAllContents(id, path)).First();
        }

        public static async Task<IEnumerable<RepositoryContent>> GetAllDownloadedContents(this IRepositoryContentsClient source, long id, string path)
        {
            var contents = await source.GetAllContents(id, path); //GetAllContents on directories doesn't download content, only individual call to file does.
            var tasks = contents.Select(async c => (await source.GetAllContents(id, c.Path)).First()); 
            return await Task.WhenAll(tasks);
        }
    }
}
