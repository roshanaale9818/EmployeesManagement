using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.modals
{
    public class AppDbContext:DbContext
    {
        //to pass configurtaion information to the DB context use DbContextOptions instance
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        //we use this for querying the database and any operation to database
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            //seeding the data to our database with migration
            modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    {
                        Id = 1,
                        Name = "Roshan",
                        Department = "Development",
                        Email = "roshan@gmail.com"
                    }
                    );
            

        }
    }
}
