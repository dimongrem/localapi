using System;

namespace localapi.Infrastructure.Models
{
    public class DbPullRequestIteration
    {
        public DateTime StartTime { get; set; }
        public string[] Comments { get; set; }
        public string[] Reviewers { get; set; }
    }
}