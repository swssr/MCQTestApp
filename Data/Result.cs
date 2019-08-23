using System.Collections.Generic;

namespace Data
{
    public class Result
    {
        public int Id { get; set; }
        public List<int> Choices { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public void AddChoice(int choice) => Choices.Add(choice);
    }
}
