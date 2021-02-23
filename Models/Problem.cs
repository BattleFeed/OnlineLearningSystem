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
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }
        public int CorrectChoiceID { get; set; }
    }
}
