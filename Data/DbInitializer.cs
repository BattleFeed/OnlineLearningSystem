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
            context.Database.EnsureCreated();

            // DB is not empty with courses
            if (context.Courses.Any())
            {
                return;
            }

            var courses = new Course[]
            {
                new Course{ Name="深入浅出WPF", Intro="课程：深入浅出WPF\n主讲：刘铁猛 (Timothy Liu)\n微软社区精英\n博客：http://www.cnblogs.com/prism\n邮箱：wpfgeek @live.com"},
                new Course{ Name="Getting Started with Asynchronous Programming in .NET", Intro="转载自：https://www.pluralsight.com/"},
            };
            foreach (var course in courses)
            {
                context.Courses.Add(course);
            }
            context.SaveChanges();

            var sections = new Section[]
            {
                new Section{ SectionID = 1, CourseID=1, Name="Lesson_01", Intro="剖析最简单的WPF程序"},
                new Section{ SectionID = 2, CourseID=1, Name="Lesson_02", Intro="浅析用户界面的树形结构"},
                new Section{ SectionID = 3, CourseID=1, Name="Lesson_03", Intro="在XAML中为对象属性赋值"},
                new Section{ SectionID = 1, CourseID=2, Name="Lesson_01", Intro="Introduction"},
                new Section{ SectionID = 2, CourseID=2, Name="Lesson_02", Intro="Overview"},
                new Section{ SectionID = 3, CourseID=2, Name="Lesson_03", Intro="What is asynchronous programming"},
            };
            foreach (var section in sections)
            {
                context.Sections.Add(section);
            }
            context.SaveChanges();

            var problems = new Problem[]
            {
                new Problem{ SectionID=1, Description="Question 1", CorrectChoiceID=1, Choice1="Choice1", Choice2="Choice2", Choice3="Choice3", Choice4="Choice4"},
                new Problem{ SectionID=1, Description="Question 2", CorrectChoiceID=2, Choice1="Choice1", Choice2="Choice2", Choice3="Choice3", Choice4="Choice4"},
                new Problem{ SectionID=1, Description="Question 3", CorrectChoiceID=3, Choice1="Choice1", Choice2="Choice2", Choice3="Choice3", Choice4="Choice4"},
                new Problem{ SectionID=1, Description="Question 4", CorrectChoiceID=4, Choice1="Choice1", Choice2="Choice2", Choice3="Choice3", Choice4="Choice4"},
            };
            foreach (var problem in problems)
            {
                context.Problems.Add(problem);
            }
            context.SaveChanges();
        }
    }
}
