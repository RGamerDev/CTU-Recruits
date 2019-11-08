using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTU_Recruits.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobSeeker>().HasData(
                new JobSeeker()
                {
                    Id = 1,
                    Name = "Mary",
                    Skills = "abc",
                    YearsOfExperience = 1,
                    Description = "jkfld;ajskgl;ag",
                    PhotoPath = @"~/Images/Mary.jpg",
                    CVPath = "~/Images/CV.png",
                    PublicCV = true
                },
                new JobSeeker()
                {
                    Id = 2,
                    Name = "John",
                    Skills = "def",
                    YearsOfExperience = 1,
                    Description = "jkfld;ajskgl;ag",
                    PhotoPath = @"~/Images/John.jpg",
                    CVPath = "~/Images/CV.png",
                    PublicCV = true
                },
                new JobSeeker()
                {
                    Id = 3,
                    Name = "Sam",
                    Skills = "ghi",
                    YearsOfExperience = 1,
                    Description = "jkfld;ajskgl;ag",
                    PhotoPath = @"~/Images/Sam.jpg",
                    CVPath = "~/Images/CV.png",
                    PublicCV = true
                });

            modelBuilder.Entity<Employer>().HasData
                (
                    new Employer() { Id = 1, Name = "Mary", CompanyName = "Techer", Description = "jfkdlsahjkdasghsdjka" },
                    new Employer() { Id = 2, Name = "John", CompanyName = "ITD", Description = "jfkdlsahjkdasghsdjka" },
                    new Employer() { Id = 3, Name = "Sam", CompanyName = "UMC", Description = "jfkdlsahjkdasghsdjka" }
                );
        }
    }
}
