using System;
using System.Collections.Generic;
using System.Text;

namespace Translator.Domain.Models
{
    public class Word : DomainObject
    {
        public Language From { get; set; }
        
        public Language To { get; set; }

        public string Native { get; set; }

        public List<string> Translations { get; set; }

        public List<string> NounsTranslations { get; set; }

        public List<string> AdjectivesTranslations { get; set; }

        public List<string> VerbsTranslations { get; set; }

        public override int GetHashCode()
        {
            return Native.GetHashCode();
        }
    }
}
