using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Test
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public DateTime DateTime { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<Result> Results { get; set; }

        public Test(string studentName, DateTime dateTime, ICollection<Question> questions)
        {
            this.StudentName = studentName;
            this.DateTime = dateTime;
            this.Questions = questions;
        }
    }
}
