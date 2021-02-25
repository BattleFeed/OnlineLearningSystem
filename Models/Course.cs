using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OnlineLearningSystem.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public string Intro { get; set; }

        public ICollection<Section> Sections { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
