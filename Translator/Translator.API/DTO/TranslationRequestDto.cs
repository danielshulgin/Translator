using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Translator.API.DTO
{
    public class TranslationRequestDto
    {
        public readonly string Word;

        
        public TranslationRequestDto(string word)
        {
            Word = word;
        }
    }
}
