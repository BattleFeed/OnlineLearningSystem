using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OnlineLearningSystem.Models
{
    public class Course
    {
        [DisplayName("Course ID")]
        public int ID { get; set; }

        [DisplayName("Course Name")]
        public string Name { get; set; }

        public int Score { get; set; }

        [DisplayName("Introduction")]
        public string Intro { get; set; }

        public ICollection<Section> Sections { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
