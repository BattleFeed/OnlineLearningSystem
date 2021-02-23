using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineLearningSystem.Models;

namespace OnlineLearningSystem.Data
{
    public class UserContext : IdentityDbContext<User>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Problem> Problems { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>().ToTable("Course");
            builder.Entity<Section>().ToTable("Sections");
            builder.Entity<Problem>().ToTable("Problems");

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
