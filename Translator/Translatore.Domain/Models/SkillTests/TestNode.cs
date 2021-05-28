using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Translator.Domain.Models.SkillTests
{
    public abstract class TestNode
    {
        public List<TestNode> Children { get; private set; }


        public TestNode(List<TestNode> children)
        {
            Children = children;
        }

        public abstract int CalculateFullPoints();

        public abstract int CalculateEarnedPoints();
    }
}
