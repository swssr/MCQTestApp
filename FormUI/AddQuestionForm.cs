using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class AddQuestionForm : Form
    {
        public AddQuestionForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            TestController tc = new TestController();
            string optText = txtOptions.Text;
            List<string> options = optText.Split(new char[] {','}).ToList();

            var option = tc.AddQuestion(txtQuestion.Text, options, int.Parse(txtAnswer.Text));

            MessageBox.Show($"Question {option.Text.Substring(0, 10)}... added!");

            AddQuestionForm_Load(sender,  e);
        }

        private void AddQuestionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
