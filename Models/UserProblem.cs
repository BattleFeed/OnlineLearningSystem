using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningSystem.Models
{
    public class UserProblem
    {
        public string UserId { get; set; }
        public int ProblemID { get; set; }
        public bool IsCorrect { get; set; }

        [ForeignKey("UserId")]
        public User User{ get; set; }
        public Problem Problem { get; set; }
    }
}
