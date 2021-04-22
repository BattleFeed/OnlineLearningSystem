using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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

        [DisplayName("Choice 1")]
        public string Choice1 { get; set; }
        [DisplayName("Choice 2")]
        public string Choice2 { get; set; }
        [DisplayName("Choice 3")]
        public string Choice3 { get; set; }
        [DisplayName("Choice 4")]
        public string Choice4 { get; set; }

        [DisplayName("Correct Choice Number")]
        public int CorrectChoiceID { get; set; }

        public Section Section { get; set; }
        public ICollection<UserScoreHistory> UserScoreHistories { get; set; }
    }
}
