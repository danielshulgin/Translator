using System.Linq;
using System.Threading.Tasks;
using Translator.API.Controllers.RequestChainOfResponsibility.Base;
using Translator.API.DTO;
using Translator.Domain.Models;
using Translator.EntityFramework.Services;

namespace Translator.API.Controllers.RequestChainOfResponsibility.TranslationRequestHandlers
{
    public class SentencesHandler : BaseRequestHandler<TranslationRequestDto, TranslationResponseDto>
    {
        private readonly IDbGenericService<Sentence> _sentenceService;
        
        
        public SentencesHandler(IDbGenericService<Sentence> sentenceService)
        {
            _sentenceService = sentenceService;
        }
        
        public override async Task<TranslationResponseDto> Handle(TranslationRequestDto translationRequestDto, TranslationResponseDto translationResponseDto)
        {
            var allSentences = await _sentenceService.GetAll();
            var sentences = allSentences
                .Where(s => s.Text.Contains(translationRequestDto.Word))
                .Select(s => new SentenceDto(){Translation = s.Translation, Text = s.Text});
            translationResponseDto.Sentences = sentences.ToList();
            
            return await base.Handle(translationRequestDto, translationResponseDto);
        }
    }
}