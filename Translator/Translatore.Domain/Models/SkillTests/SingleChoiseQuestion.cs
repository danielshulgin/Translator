using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Translator.Domain.Models.SkillTests
{
    public class SingleChoiseQuestion : TestNode
    {
        public string QuestionText { get; private set; }

        public List<string> Answers { get; private set; }

        public int RightAnswerIndex { get; private set; }

        public int UserAnswer { get; private set; }

        public int Points { get; private set; }


        public SingleChoiseQuestion(int points, string questionText, List<string> answers, int rightAnswerIndex, int userAnswer)
            : base(new List<TestNode>())
        {
            QuestionText = questionText;
            Answers = answers;
            RightAnswerIndex = rightAnswerIndex;
            Points = points;
            UserAnswer = userAnswer;
        }

        public override int CalculateEarnedPoints()
        {
            if (RightAnswerIndex == UserAnswer)
            {
                return Points;
            }
            return 0;
        }

        public override int CalculateFullPoints()
        {
            return Points;
        }
    }
}
