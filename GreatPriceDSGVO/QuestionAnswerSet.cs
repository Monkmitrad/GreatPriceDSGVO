using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatPriceDSGVO
{
    public class QuestionAnswerSet
    {
        private readonly string category;
        private readonly string question;
        private readonly string answer;
        private readonly int questionNumber;

        public QuestionAnswerSet(string category, string question, string answer, int questionIndex)
        {
            this.category = category;
            this.question = question;
            this.answer = answer;
            this.questionNumber = questionIndex;
        }

        public string GetCategory()
        {
            return category;
        }

        public string GetQuestion()
        {
            return question;
        }

        public string GetAnswer()
        {
            return answer;
        }

        public int GetQuestionNumber()
        {
            return questionNumber;
        }
    }
}
