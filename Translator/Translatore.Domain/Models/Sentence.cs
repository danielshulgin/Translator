using System.Collections.Generic;

namespace Translator.Domain.Models
{
    public class Sentence : DomainObject
    {
        public Language From { get; set; }

        public Language To { get; set; }

        public string Text { get; set; }

        public string Translation { get; set; }
    }
}