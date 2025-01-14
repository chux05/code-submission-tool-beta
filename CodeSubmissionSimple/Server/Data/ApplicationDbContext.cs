﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSubmissionSimple.Shared;
using Microsoft.EntityFrameworkCore;

namespace CodeSubmissionSimple.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Submission> Submissions { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<AppUser> AppUser { get; set; }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<TestStatus> TestStatuses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            {
                modelBuilder.Entity<Submission>()
                    .HasOne(a => a.Candidate)
                    .WithOne(b => b.Submission)
                    .HasForeignKey<Candidate>(b => b.SubmissionId);
            }

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    Email = "ashton@gmail.com",
                    Role = "Admin",
                    PasswordHash = "1254wsde9632fgty"
                },
                 new AppUser
                 {
                     Id = 2,
                     Email = "hi@ngn.com",
                     Role = "Developer",
                     PasswordHash = "1254wsdeu9632fgty"
                 }
                );


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "jj@gmail.com",
                    Password = "1234",
                    Role = "User"

                },
                    new User
                    {
                        Id = 2,
                        FirstName = "Sally",
                        LastName = "Smith",
                        Email = "ss@gmail.com",
                        Password = "1234",
                        Role = "HR"

                    }
                );


            modelBuilder.Entity<Submission>().HasData(new Submission
            {
                SubmissionId = 1,
                isCompleted = false
            });

            modelBuilder.Entity<Submission>().HasData(new Submission
            {
                SubmissionId = 2,
                isCompleted = false
            });

            //Tests
            modelBuilder.Entity<Candidate>().HasData(new Candidate
            {
                Id = 3,
                Email = "chux05@hotmail.com",
                Role = "Candidate",
                PasswordHash = "1254wsdeu96sads2fgty",
                Name = "Promise",
                Surname = "Email",
                SubmissionId = 1
            });

            modelBuilder.Entity<Candidate>().HasData(new Candidate
            {
                Id = 4,
                Email = "ajdk@gmail.com",
                Role = "Candidate",
                PasswordHash = "12sf343sads2fgty",
                Name = "Tshgo",
                Surname = "Mochaki",
                SubmissionId = 2
            });

            //Questions - deprecated 
            modelBuilder.Entity<Question>().HasData(new Question
            {
                QuestionId = 1,
                Description = "Given a string x, reverse and return it",
                Langauge = "Python",
                CodeStub = "def reverse_string():",
            });

            modelBuilder.Entity<Question>().HasData(new Question
            {
                QuestionId = 2,
                Description = "Given a string S consisting only '0's and '1's,  find the last index of the '1' present in it.",
                Langauge = "C#",
                CodeStub = @"
            public class Solution{
                public int LastIndexOfOne(string S) {
                
                    return 0;  
                }
            }",
            });

            modelBuilder.Entity<Question>().HasData(new Question
            {
                QuestionId = 3,
                Description = "Given a database 'Users', write a query to display all the users",
                Langauge = "SQL",
                CodeStub = "",
            });

            modelBuilder.Entity<Question>().HasData(new Question
            {
                QuestionId = 4,
                Description = @"Given a piece of html, change the text to be red using the 'red-card class
<div id=""firstDiv"" class=""red-card"">",
                Langauge = "CSS",
                CodeStub = "",
            });

            modelBuilder.Entity<Question>().HasData(new Question
            {
                QuestionId = 5,
                Description = @"Given a piece of html, change the text to be pink using Javascript
<div id=""firstDiv"">",
                Langauge = "JavaScript",
                CodeStub = "",
            });

            modelBuilder.Entity<Question>().HasData(new Question
            {
                QuestionId = 6,
                Description = "Given a farenheit variable, convert it to Celcius ",
                Langauge = "JavaScript",
                CodeStub = @"function toCelsius(fahrenheit) {
}",
            });

            modelBuilder.Entity<Question>().HasData(new Question
            {
                QuestionId = 7,
                Description = "Merge two sorted arrays and return it as a single array.",
                Langauge = "C#",
                CodeStub = @"
            public class Solution{
                public int[] MergeArrays(int[] nums1, int[]nums2) {
          
                }
            }",
            });

            modelBuilder.Entity<TestStatus>().HasData(new TestStatus
            {
                TestStatusId = 1,
                QuestionId = 1,
                Code = "",
                SubmissionId = 1
            });

            modelBuilder.Entity<TestStatus>().HasData(new TestStatus
            {
                TestStatusId = 2,
                QuestionId = 2,
                Code = "",
                SubmissionId = 1
            });

            modelBuilder.Entity<TestStatus>().HasData(new TestStatus
            {
                TestStatusId = 3,
                QuestionId = 6,
                Code = "",
                SubmissionId = 1
            });


        }
    }
}
