using System;
using System.Linq;
using System.Threading.Tasks;
using Translator.API.DTO;
using Translator.Domain.Models;
using Translator.EntityFramework.Services;

namespace Translator.API.Controllers.RequestChainOfResponsibility
{
    public class LogMessageHandler<TRequest, TResponse> : BaseRequestHandler<TRequest, TResponse>
    {
        private readonly IDbGenericService<LogMessage> _logMessageService;
        
        private readonly string _message;
        
        
        public LogMessageHandler(IDbGenericService<LogMessage> logMessageService, string message)
        {
            _message = message;
            _logMessageService = logMessageService;
        }
        
        public override async Task<TResponse> Handle(TRequest request, TResponse response)
        {
            var logMessage = new LogMessage(_message, DateTime.Now);
            await _logMessageService.Create(logMessage);
            
            return await base.Handle(request, response);
        }
    }
}