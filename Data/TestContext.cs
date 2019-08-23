using System.Data.Entity;

namespace Data
{
    public class TestContext : DbContext
    {
        public TestContext() : base("MCQDBData") { }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
    }
}
