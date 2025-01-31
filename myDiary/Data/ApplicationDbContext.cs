using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myDiary.Models;

namespace myDiary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DateTime fixedDate = new DateTime(2024, 1, 30, 12, 0, 0);

            //Creating new diary entry to add to database
            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry {
                Id = 1,
                Title="Went Hiking",
                Content="Went hiking with Joe!",
                Created = fixedDate

                },

                new DiaryEntry {
                    Id = 2,
                    Title="Went Shopping",
                    Content="Went shopping with Joe!",
                    Created = fixedDate
                }
            );
        }

    }
}
