using System.Threading.Tasks;
using localapi.Services.Models.CodeRepository;

namespace localapi.Services 
{
    public interface ICodeRepositoryEventService
    {
        Task ProcessEventAsync(ProcessEventParams eventParams);
    }
}