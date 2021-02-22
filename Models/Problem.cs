using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningSystem.Models
{
    public class Problem
    {
        public int ID { get; set; }
        public int SectionID { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public int CorrectChoiceID { get; set; }
        public ICollection<string> Choices { get; set; }
    }
}
