using System.Linq;
using System.Threading.Tasks;
using Translator.API.Controllers.RequestChainOfResponsibility.Base;
using Translator.API.DTO;
using Translator.Domain.Models;
using Translator.EntityFramework.Services;

namespace Translator.API.Controllers.RequestChainOfResponsibility.TranslationRequestHandlers
{
    public class MainTranslationsHandler : BaseRequestHandler<TranslationRequestDto, TranslationResponseDto>
    {
        private readonly IDbGenericService<Word> _wordService;
        
        
        public MainTranslationsHandler(IDbGenericService<Word> wordService)
        {
            _wordService = wordService;
        }
        
        public override async Task<TranslationResponseDto> Handle(TranslationRequestDto translationRequestDto, 
            TranslationResponseDto translationResponseDto)
        {
            var word = (await _wordService.GetAll()).First(w => w.Native == translationRequestDto.Word);
            if (word != null)
            {
                translationResponseDto.Translations = word.Translations;
                translationResponseDto.Native = word.Native;
                translationResponseDto.AdjectivesTranslations = word.AdjectivesTranslations;
                translationResponseDto.VerbsTranslations = word.VerbsTranslations;
                translationResponseDto.NounsTranslations = word.NounsTranslations;
            }
            
            return await base.Handle(translationRequestDto, translationResponseDto);
        }
    }
}