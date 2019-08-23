using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestUI
{
    public partial class TestForm : Form
    {
        // Class: QuizForm
        // Provide the user the questions and possible answers (data)
        // Provides the user the means to answer the question
        // Front End Presentation Layer

        // support variables
        private DataBase m_dataBase=null;
        private Test m_quiz = null;
        private int m_questionNumber = 0;

        public TestForm()
        {
            InitializeComponent();
            // middle tier components
            m_dataBase = new DataBase();
            m_quiz = new Test();

        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            // subscribers subscribe to publisher's events
            // this is what we call loooooooooose coupling...
            // publisher.Event += subscriber.Method
            m_dataBase.QuestionAcquired += this.DataBase_QuestionAcquired;
            m_dataBase.AnswerProvided += m_quiz.DataBase_AnswerProvided;
            m_dataBase.DatabaseLoaded += m_quiz.DataBase_OnLoad;
            m_quiz.AnswerEvaluated += this.Quiz_AnswerEvaluated;
            m_quiz.QuizEnded += this.Quiz_QuizEnded;

            // Other initializations and state starts
            m_dataBase.QueryDatabase();
            btnSubmit.Enabled = GetSubmitButtonEnabledState();
            UpdateStatusPanels(0, 0, 0m);
            SetupSummaryListView();
        }

        #region Event Subscriptions
        public void DataBase_QuestionAcquired(object sender, QuestionEventArgs e)
        {
            // Method: DataBase_QuestionAcquired
            // QuizForm subscriber uses data from publisher DataBase
            // Present the question to the user/quiz taker
            Question q = e.Question;
            lblQuestionNumber.Text = q.QuestionNumber.ToString();
            txtQuestion.Text = q.QuestionText;
            optA.Text = q.AnswerTextA;
            optB.Text = q.AnswerTextB;
            optC.Text = q.AnswerTextC;
            optD.Text = q.AnswerTextD;
        }

        public void Quiz_AnswerEvaluated(object sender, EvaluationEventArgs e)
        {
            UpdateStatusPanels(e.CorrectlyAnswered, e.IncorrectlyAnswered, e.SuccessPercentage);
            MessageBox.Show(e.Feedback, "Multiple Choice Quiz", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Quiz_QuizEnded(object sender, QuizEndSummaryEventArgs e)
        {
            pnlSummary.BringToFront();

            foreach(SummaryItem listItem in e.QuizSummary)
            {
                ListViewItem i = new ListViewItem();
                i.Text = listItem.QuestionNumber.ToString();
                ListViewItem.ListViewSubItem s1 = new ListViewItem.ListViewSubItem();
                s1.Text = listItem.CorrectAnswer;
                i.SubItems.Add(s1);
                ListViewItem.ListViewSubItem s2 = new ListViewItem.ListViewSubItem();
                s2.Text = listItem.SubmittedAnswer;
                i.SubItems.Add(s2);
                ListViewItem.ListViewSubItem s3 = new ListViewItem.ListViewSubItem();
                s3.Text = listItem.Feedback;
                i.SubItems.Add(s3);

                lvwSummary.Items.Add(i);
            }

            lblAnlysis.Text = e.Analysis;
        }

        #endregion

        #region UI State Management

        private void ResetAnswers()
        {
            optA.Checked = false;
            optB.Checked = false;
            optC.Checked = false;
            optD.Checked = false;
        }

        private void UpdateStatusPanels(int correctAnswered, int incorrectAnswered, decimal successPercentage)
        {
            tsslCorrect.Text = $"Answered Correctly: {correctAnswered}";
            tsslIncorrect.Text = $"Answered Incorrectly: {incorrectAnswered}";
            tsslPercent.Text = $"Success Rate: {successPercentage} %";
        }

        private Boolean  GetSubmitButtonEnabledState()
        {
            // default to false
            Boolean result = false;

            // Conditions for true
            // one of the four radio buttons: optA, optB, optC or optD
            // must have a checked value of ture
            result = ((optA.Checked == true) || (optB.Checked == true) || (optC.Checked == true) || (optD.Checked == true));

            return result;
        }
        #endregion

        #region Ui Control Events
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // send user answer to the quiz engine for evaluation
            m_quiz.Evaluate(m_questionNumber, GetSelectedAnswer());
            // reset the answers
            ResetAnswers();
            // change submit button state
            btnSubmit.Enabled = GetSubmitButtonEnabledState();
            // advanced the question number
            m_questionNumber++;
            // get a new questino
            m_dataBase.GetQuestion(m_questionNumber);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            m_questionNumber++;
            m_dataBase.GetQuestion(m_questionNumber);
            pnlQuestion.BringToFront();
        }

        private void optA_Click(object sender, EventArgs e)
        {
            // change submit button state
            btnSubmit.Enabled = GetSubmitButtonEnabledState();
        }

        private void optB_Click(object sender, EventArgs e)
        {
            // change submit button state
            btnSubmit.Enabled = GetSubmitButtonEnabledState();
        }

        private void optC_Click(object sender, EventArgs e)
        {
            // change submit button state
            btnSubmit.Enabled = GetSubmitButtonEnabledState();
        }

        private void optD_Click(object sender, EventArgs e)
        {
            // change submit button state
            btnSubmit.Enabled = GetSubmitButtonEnabledState();
        }
        #endregion

        #region Supporting Subroutines

        private void SetupSummaryListView()
        {
            lvwSummary.Columns.Clear();
            lvwSummary.Columns.Add("Question", 75, HorizontalAlignment.Left);
            lvwSummary.Columns.Add("Correct", 75, HorizontalAlignment.Left);
            lvwSummary.Columns.Add("Submitted", 75, HorizontalAlignment.Left);
            lvwSummary.Columns.Add("Feedback", 100, HorizontalAlignment.Left);
        }

        private string GetSelectedAnswer()
        {
            string answer = string.Empty;

            if(optA.Checked==true) { answer = "A"; }
            if (optB.Checked == true) { answer = "B"; }
            if (optC.Checked == true) { answer = "C"; }
            if (optD.Checked == true) { answer = "D"; }

            return answer;
        }

        #endregion
    }
}
