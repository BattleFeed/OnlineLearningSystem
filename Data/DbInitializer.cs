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
            
            


        }
    }
}
