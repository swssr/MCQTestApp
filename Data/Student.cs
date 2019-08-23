using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }

        public ICollection<Result> Results { get; set; }
    }
}
