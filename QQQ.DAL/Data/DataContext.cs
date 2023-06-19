using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using QQQ.Model;

namespace QQQ.DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Interview> InterViews { get; set; }
        public DbSet<Event> Events { get; set; }
      
    }
}
