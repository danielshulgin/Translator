using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Translator.Domain.Models.SkillTests
{
    public class GroupTestNode : TestNode
    {
        public GroupTestNode(List<TestNode> children) : base(children)
        {

        }

        public override int CalculateFullPoints()
        {
            var points = 0;
            foreach (var child in Children)
            {
                points += child.CalculateFullPoints();
            }
            return points;
        }

        public override int CalculateEarnedPoints()
        {
            var points = 0;

            for (int i = 0; i < Children.Count; i++)
            {
                points += Children[i].CalculateEarnedPoints();

            }
            return points;
        }
    }
}
