using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Translator.API.Controllers.RequestChainOfResponsibility
{
    public interface IRequestHandler<in TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request, TResponse response);
    }
}