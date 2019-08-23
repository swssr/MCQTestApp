using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUI
{
    public class QuizEndSummaryEventArgs : EventArgs
    {
        private ArrayList m_summary=null;
        private string m_analysis = string.Empty;

        public QuizEndSummaryEventArgs(ArrayList summary, string analysis)
        {
            m_analysis = analysis;
            m_summary = summary;
        }

        public ArrayList QuizSummary
        {
            get { return m_summary; }
        }

        public string Analysis
        {
            get { return m_analysis; }
        }
    }
}
