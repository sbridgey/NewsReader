using System;
using Microsoft.EntityFrameworkCore;

namespace NewsReader.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {
        }

        public DbSet<NewStories> NewsStories { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }    }
}
