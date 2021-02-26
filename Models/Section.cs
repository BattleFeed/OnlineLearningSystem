using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningSystem.Models
{
    public class Section
    {
        public int ID { get; set; }

        [DisplayName("Section ID")]
        public int SectionID { get; set; } // 课程中为第x节

        [DisplayName("Section Name")]
        public string Name { get; set; }       

        public int Score { get; set; }

        [DisplayName("Introduction")]
        public string Intro { get; set; }       
        public string Content { get; set; }
        
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public ICollection<Problem> ProblemSet { get; set; }
    }
}
