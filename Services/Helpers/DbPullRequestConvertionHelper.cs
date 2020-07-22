using System;
using localapi.Infrastructure.Models;
using localapi.Services.Models.CodeRepository;

namespace localapi.Services.Helpers
{
    public static class DbPullRequestConvertionHelper
    {
        public static DbPullRequest ToDbModel(this ProcessEventParams source, DateTime eventTime)
        {
            return new DbPullRequest
            {
                ExternalId = source.Id,
                Title = source.Title,
                Description = source.Description,
                Iterations = new DbPullRequestIteration[]
                {
                    new DbPullRequestIteration
                    {
                        StartTime = eventTime
                    }
                }
            };
        }
    }
}