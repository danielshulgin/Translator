using System.Linq;
using System.Threading.Tasks;
using Translator.API.Controllers.RequestChainOfResponsibility.Base;
using Translator.API.DTO;
using Translator.Domain.Models;
using Translator.EntityFramework.Services;

namespace Translator.API.Controllers.RequestChainOfResponsibility.TranslationRequestHandlers
{
    public class CollocationsHandler : BaseRequestHandler<TranslationRequestDto, TranslationResponseDto>
    {
        private readonly IDbGenericService<Collocation> _collocationService;
        
        
        public CollocationsHandler(IDbGenericService<Collocation> collocationService)
        {
            _collocationService = collocationService;
        }
        
        public override async Task<TranslationResponseDto> Handle(TranslationRequestDto translationRequestDto,
            TranslationResponseDto translationResponseDto)
        {
            var allCollocations = await _collocationService.GetAll();
            var collocations = allCollocations
                .Where(c => c.Words.Contains(translationRequestDto.Word))
                .Select(c => new CollocationDto(){Translation = c.Translation, Words = c.Words});
            translationResponseDto.Collocations = collocations.ToList();
            
            return await base.Handle(translationRequestDto, translationResponseDto);
        }
    }
}