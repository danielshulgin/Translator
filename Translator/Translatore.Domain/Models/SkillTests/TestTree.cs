using System;
using System.Collections.Generic;
using System.Text;
using Translator.Domain.Models;

namespace Translator.Domain.SkillTests
{
    public class TestTree : DomainObject
    {
        public string JsonValue { get; private set; }


        public TestTree(string jsonValue)
        {
            this.JsonValue = jsonValue;
        }
    }
}

