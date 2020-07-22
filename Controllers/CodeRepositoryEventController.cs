using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using localapi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using localapi.Controllers.Models;
using Serilog;
using localapi.Controllers.Helpers;

namespace localapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodeRepositoryEventController : ControllerBase
    {
        private readonly ILoggingService _loggingService;
        private readonly ICodeRepositoryEventService _codeRepositoryEventService;

        public CodeRepositoryEventController(ILoggingService loggingService, ICodeRepositoryEventService codeRepositoryEventService)
        {
            _loggingService = loggingService;
            _codeRepositoryEventService = codeRepositoryEventService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostCodeRepositoryEventApiIn repositoryEvent) 
        {
            var repositoryEventModel = repositoryEvent.ToLogicModel();
            await _codeRepositoryEventService.ProcessEventAsync(repositoryEventModel);
            return Ok();
        }
    }
}
