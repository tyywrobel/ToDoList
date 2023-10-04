using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ToDoList.Models
{
    public class ListContext:DbContext
    {
        public ListContext(DbContextOptions<ListContext> options)
            : base(options)
        { }
        public DbSet<TheList> GetItDone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TheList>().HasData(
                new TheList
                {
                    ID = 1,
                    Description = "Do CIT218 Homework",
                    CreatedDate = DateTime.Today
                },
                new TheList {
                    ID = 2,
                    Description="Take a nap",
                    CreatedDate = DateTime.Today
                },
               new TheList {
                    ID = 3,
                    Description = "Work Out",
                    CreatedDate = DateTime.Today
                }
                ); 
        }
     }
}
