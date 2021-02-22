using Microsoft.AspNetCore.Identity;
using OnlineLearningSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningSystem.Data
{
    public class DbInitializer
    {
        public static void Initialize(UserContext context)
        {
            // DB is not empty
            if (context.Users.Any())
            {
                return;
            }
            
            //var users = new User[]
            //{
            //    new User{ UserName = "Alpha", Email = "Alpha@example.com", EnrollmentDate = DateTime.Now, EmailConfirmed = true},
            //    new User{ UserName = "Bravo", Email = "Bravo@example.com", EnrollmentDate = DateTime.Now, EmailConfirmed = true},
            //    new User{ UserName = "Charlie", Email = "Charlie@example.com", EnrollmentDate = DateTime.Now, EmailConfirmed = true},
            //    new User{ UserName = "Delta", Email = "Delta@example.com", EnrollmentDate = DateTime.Now, EmailConfirmed = true},
            //    new User{ UserName = "Echo", Email = "Echo@example.com", EnrollmentDate = DateTime.Now, EmailConfirmed = true},
            //};


        }
    }
}
