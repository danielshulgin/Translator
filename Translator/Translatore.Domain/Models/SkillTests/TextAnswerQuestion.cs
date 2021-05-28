using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Translator.Domain.Models.SkillTests
{
    public class TextAnswerQuestion : TestNode
    {
        public string QuestionText { get; private set; }

        public string Answer { get; private set; }

        public string UserAnswer { get; private set; }

        public int Points { get; private set; }


        public TextAnswerQuestion(int points, string questionText, string answer, string userAnswer)
            : base(new List<TestNode>())
        {
            QuestionText = questionText;
            Answer = answer;
            Points = points;
            UserAnswer = userAnswer;
        }

        public override int CalculateFullPoints()
        {
            return Points;
        }

        public override int CalculateEarnedPoints()
        {
            if (Answer == UserAnswer)
            {
                return Points;
            }
            return 0;
        }
    }
}
