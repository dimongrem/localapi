using localapi.Controllers.Models;
using localapi.Services.Models.CodeRepository;

namespace localapi.Controllers.Helpers
{
    public static class CodeRepositoryConvertionHelper
    {
        public static ProcessEventParams ToLogicModel(this PostCodeRepositoryEventApiIn source)
        {
            return new ProcessEventParams
            {
                Id = source.Id,
                Title = source.Title,
                Description = source.Description,
                Author = source.Author,
                FileUrls = source.FileUrls
            };
        }
    }
}