using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningSystem.Models
{
    public class Enrollment
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }
        public bool IsCompleted { get; set; } // Whether the user has completed the course

        public Course Course { get; set; }
        public User User { get; set; }
    }
}
