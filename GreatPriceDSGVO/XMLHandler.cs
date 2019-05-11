using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace GreatPriceDSGVO
{
    public class XMLHandler
    {
        private XmlDocument doc;
        private List<QuestionAnswerSet> questions = new List<QuestionAnswerSet>();
        public XMLHandler(string path)
        {
            doc = new XmlDocument();
            doc.Load(path);
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            int questionIndex = 0;
            //foreach category
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                //MessageBox.Show(node.Name);
                //foreach question
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    questions.Add(new QuestionAnswerSet(node.Name, childNode.FirstChild.InnerText, childNode.LastChild.InnerText, questionIndex));
                    questionIndex++;
                }
            }
        }

        public QuestionAnswerSet RetrieveQuestion(Position position, int questionNumber)
        {
            int category = position.GetCol() + 1;

            foreach (QuestionAnswerSet item in questions)
            {
                if(item.GetCategory() == ("category" + category))
                {
                    //MessageBox.Show(item.GetQuestion());
                    if(item.GetQuestionNumber() == questionNumber)
                    return item;
                }
            }

            return null;
        }
    }
}
