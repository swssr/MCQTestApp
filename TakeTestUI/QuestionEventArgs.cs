using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUI
{
    public class QuestionEventArgs : EventArgs
    {
        // Class: QuestionEventArgs
        // The requested data packaged and delivered to class QuizForm

        private string m_quiz = "Astronomy Quiz";
        private Question m_question = null;

        public QuestionEventArgs(Question question)
        {
            m_question = question;
        }

        public string QuizName
        {
            get { return m_quiz; }
        }

        public Question Question
        {
            get { return m_question; }
        }
    }
}
