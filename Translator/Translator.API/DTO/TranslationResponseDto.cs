using System.Collections.Generic;
using Translator.Domain.Models;

namespace Translator.API.DTO
{
    public class TranslationResponseDto
    {
        public List<string> Translations { get; set; }

        public List<string> NounsTranslations { get; set; }

        public List<string> AdjectivesTranslations { get; set; }

        public List<string> VerbsTranslations { get; set; }

        public List<CollocationDto> Collocations { get; set; }

        public List<SentenceDto> Sentences { get; set; }

        public string Native { get; set; }
    }
}