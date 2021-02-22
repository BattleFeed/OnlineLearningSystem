using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningSystem.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public string Intro { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
