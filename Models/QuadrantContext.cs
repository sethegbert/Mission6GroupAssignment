using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6GroupAssignment.Models
{
    public class QuadrantContext : DbContext
    {
        public QuadrantContext(DbContextOptions<QuadrantContext> options) : base (options)
        {

        }

        public DbSet<Quadrant> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Home" },
                new Category { CategoryID = 2, CategoryName = "School" },
                new Category { CategoryID = 3, CategoryName = "Work" },
                new Category { CategoryID = 4, CategoryName = "Church" }
            );

            mb.Entity<Quadrant>().HasData(
                new Quadrant
                {
                    EntryId = 1,
                    QuadrantNumber = 1,
                    Task = "Develop relationships",
                    DueDate = "03-01-2022",
                    Completed = false, 
                    CategoryID = 1
                }
            );
        }
    }
}
