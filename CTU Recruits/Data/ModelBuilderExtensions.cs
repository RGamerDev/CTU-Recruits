using CTU_Recruits.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTU_Recruits.Data
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
                    PublicCV = true,
                    dreamJobFound = true
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
                    PublicCV = true,
                    dreamJobFound = false
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
                    PublicCV = true,
                    dreamJobFound = false
                });

            modelBuilder.Entity<Employer>().HasData
                (
                    new Employer() { Id = 1, CompanyName = "Techer", Description = "jfkdlsahjkdasghsdjka", CompanyPhotoPath = "Building1.jpg" },
                    new Employer() { Id = 2, CompanyName = "ITD", Description = "jfkdlsahjkdasghsdjka", CompanyPhotoPath = "Building2.jpg" },
                    new Employer() { Id = 3, CompanyName = "UMC", Description = "jfkdlsahjkdasghsdjka", CompanyPhotoPath = "Building3.jpg" }
                );
        }
    }
}
