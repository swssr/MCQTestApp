using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Option
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public Option() { }
        public Option(string text)
        {
            this.Text = text;
        }
        
        
    }
}
