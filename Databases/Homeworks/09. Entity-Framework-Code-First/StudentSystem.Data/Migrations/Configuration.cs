namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            this.SeedCourses(context);
            this.SeedStudents(context);
        }

        private void SeedStudents(StudentSystemDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            context.Students.Add(new Student
            {
                FirstName = "Evlogi",
                LastName = "Hristov"
            });

            context.Students.Add(new Student
            {
                FirstName = "Ivaylo",
                LastName = "Kenov"
            });

            context.Students.Add(new Student
            {
                FirstName = "Doncho",
                LastName = "Minkov"
            });

            context.Students.Add(new Student
            {
                FirstName = "Nikolay",
                LastName = "Kostov"
            });
        }

        private void SeedCourses(StudentSystemDbContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            context.Courses.Add(new Course
            {
                Name = "Seeded course",
                Description = "Initial course for testing"
            });
        }
    }
}
