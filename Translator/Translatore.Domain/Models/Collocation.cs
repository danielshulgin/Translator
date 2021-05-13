using System.Collections.Generic;

namespace Translator.Domain.Models
{
    public class Collocation : DomainObject
    {
        public Language From { get; set; }

        public Language To { get; set; }

        public List<string> Words { get; set; }

        public string Translation { get; set; }
    }
}