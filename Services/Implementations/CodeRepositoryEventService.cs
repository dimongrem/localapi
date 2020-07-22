using System;
using System.Threading.Tasks;
using localapi.Infrastructure;
using localapi.Services.Models.CodeRepository;
using localapi.Services.Helpers;

namespace localapi.Services.Implementations 
{
    public class CodeRepositoryEventService : ICodeRepositoryEventService
    {
        private IPullRequestRepository _repository;
        public CodeRepositoryEventService(IPullRequestRepository repository)
        {
            _repository = repository;
        }
        public async Task ProcessEventAsync(ProcessEventParams eventParams)
        {
            DateTime date = DateTime.UtcNow;
            var model = eventParams.ToDbModel(date);
            await _repository.AddAsync(model);
        } 
    }
}