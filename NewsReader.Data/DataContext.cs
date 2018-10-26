using System;
using Microsoft.EntityFrameworkCore;

namespace NewsReader.Data
{
    public class DataContext : DbContext
    {
        public ApiContext(DbContextOptions<DataContext> options) 
            : base(options)
        {
        }

        public DbSet<NewStories> Employees { get; set; }
        public DbSet<Suppliers> EmployeeDetails { get; set; }    }
}
