using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningSystem.Models
{
    public class User:IdentityUser
    {
        [PersonalData]
        public DateTime EnrollmentDate { get; set; }

        [PersonalData]
        public int Score { get; set; }

        [PersonalData]
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
