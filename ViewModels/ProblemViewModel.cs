using OnlineLearningSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningSystem.ViewModels
{
    public class ProblemVM
    {
        public int ID { get; set; } // for binding        
        [Required]
        public int? SelectedAnswer { get; set; } // for binding

        public int CorrectAnswer { get; set; }
        public int Score { get; set; }

        public Problem Problem { get; set; }
    }

    public class ProblemPageVM
    {
        public int SectionID { get; set; }
        // public string Name { get; set; }
        public List<ProblemVM> Problems { get; set; }
    }
}
