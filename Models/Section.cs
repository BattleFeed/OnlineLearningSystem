using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningSystem.Models
{
    public class Section
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public int CourseID { get; set; }
        public int Score { get; set; }
        public string Intro { get; set; }
        public Course Course { get; set; }

        public string Content { get; set; }

        public ICollection<Problem> ProblemSet { get; set; }
    }
}
