using System.Linq;
using System.Threading.Tasks;
using Translator.API.DTO;
using Translator.EntityFramework.Services;
using System.Collections.Generic;
using Translator.Domain.Models;

namespace Translator.API.Controllers.RequestChainOfResponsibility
{
    public class TranslationHandler : BaseRequestHandler<string, TranslationResponseDto>
    {
        private readonly DbGenericService<Word> _wordService;
        
        
        public TranslationHandler(DbGenericService<Word> wordService)
        {
            _wordService = wordService;
        }
        
        public override async Task<TranslationResponseDto> Handle(string fromWord, TranslationResponseDto translationResponseDto)
        {
            var word = (await _wordService.GetAll()).First(w => w.Native == fromWord);
            if (word != null)
            {
                translationResponseDto.Translations = word.Translations;
                translationResponseDto.Native = word.Native;
                translationResponseDto.AdjectivesTranslations = word.AdjectivesTranslations;
                translationResponseDto.VerbsTranslations = word.VerbsTranslations;
                translationResponseDto.NounsTranslations = word.NounsTranslations;
            }
            return await base.Handle(fromWord, translationResponseDto);
        }
    }
}