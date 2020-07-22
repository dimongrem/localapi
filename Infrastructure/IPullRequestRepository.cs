using System.Threading.Tasks;
using localapi.Infrastructure.Models;

namespace localapi.Infrastructure
{
    public interface IPullRequestRepository
    {
        Task AddAsync(DbPullRequest pullRequest);
    }
}