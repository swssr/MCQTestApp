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
        public ICollection<Option> Options { get; set; }

        public int AnswerId { get; set; }
        public Option CorrectAnser { get; set; }

        public Question(string text, ICollection<Option> options, Option correctAnswer)
        {
            this.Text = text;
            this.Options = options;
            this.CorrectAnser = correctAnswer;
        }


    }
}
