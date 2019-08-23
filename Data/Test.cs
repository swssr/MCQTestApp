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
        public DateTime DateTime { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Result> Results { get; set; }

        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }

        public Test(DateTime dateTime, ICollection<Question> questions)
        {
            this.DateTime = dateTime;
            this.Questions = questions;
        }
    }
}
