using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int CorrectAnswer { get; set; }

        public ICollection<Option> Options { get; set; }


        public int TestId { get; set; }
        public virtual Test Test { get; set; }

        public Question()
        {

        }
        public Question(string text, List<Option> options, int correctAnswer)
        {
            this.Text = text;
            this.Options = options;
            this.CorrectAnswer = correctAnswer;
        }


    }
}
