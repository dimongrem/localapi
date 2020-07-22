using System;

namespace localapi.Infrastructure.Models
{
    public class DbPullRequest
    {
        public Guid Id { get; set; }
        public string ExternalId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] FileExtensions { get; set; }
        public string[] Topics { get; set; }
        public string[] Layers { get; set; }
        public DbPullRequestIteration[] Iterations { get; set; }
    }
}