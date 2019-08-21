using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TestContext: DbContext
    {
        public TestContext: base("connection"){}

        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
    }
}
