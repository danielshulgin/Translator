using System.Threading.Tasks;

namespace Translator.API.Controllers.RequestChainOfResponsibility.Base
{
    public abstract class BaseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    {
        private BaseRequestHandler<TRequest, TResponse> _next;
  
        
        public virtual async Task<TResponse> Handle(TRequest request, TResponse response)
        {
            if (_next == null)
            {
                return response;
            }
            return await _next.Handle(request, response);
        }

        public BaseRequestHandler<TRequest, TResponse> AddNext(BaseRequestHandler<TRequest, TResponse> requestHandler)
        {
            if (_next != null)
            {
                _next.AddNext(requestHandler);
            }
            else
            {
                _next = requestHandler;
            }
            return this;
        }
    }
}