using System.Collections.Generic;

namespace Data
{
    public class Result
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public List<int> Choices { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public void AddChoice(int choice) => Choices.Add(choice);
    }
}
