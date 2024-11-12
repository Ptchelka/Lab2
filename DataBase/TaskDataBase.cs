using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataBase
{
    public class TaskDataBase : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=MyDatabase;User Id=sa;Password=YourPassword;");
        }
    }
}
