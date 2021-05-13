using System.Linq;
using System.Threading.Tasks;
using Translator.API.DTO;
using Translator.Domain.Models;
using Translator.EntityFramework.Services;

namespace Translator.API.Controllers.RequestChainOfResponsibility
{
    public class SentencesHandler : BaseRequestHandler<string, TranslationResponseDto>
    {
        private readonly DbGenericService<Sentence> _sentenceService;
        
        
        public SentencesHandler(DbGenericService<Sentence> sentenceService)
        {
            _sentenceService = sentenceService;
        }
        
        public override async Task<TranslationResponseDto> Handle(string fromWord, TranslationResponseDto translationResponseDto)
        {
            var allSentences = await _sentenceService.GetAll();
            var sentences = allSentences.Where(s => s.Text.Contains(fromWord))
                .Select(s => new SentenceDto(){Translation = s.Translation, Text = s.Text});
            translationResponseDto.Sentences = sentences.ToList();
            
            return await base.Handle(fromWord, translationResponseDto);
        }
    }
}