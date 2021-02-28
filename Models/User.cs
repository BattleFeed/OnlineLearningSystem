using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningSystem.Models
{
    public class User:IdentityUser
    {
        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [PersonalData]
        public DateTime EnrollmentDate { get; set; }
      
        [PersonalData]
        public int Score { get; set; }

        public ICollection<UserProblem> UserProblemSet { get; set; }
    }
}
