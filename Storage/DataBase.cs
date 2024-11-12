using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Storage
{
    public class DataBase : DbContext, ITaskCollection
    {
        public DbSet<Tassk> tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\ovtch\\Downloads\\sqlite-tools-win-x64-3470000\\tasks.db");
        }

        public async Task InitializeDatabase()
        {
            if ( !await tasks.AnyAsync())
            {
                var initialTasks = new List<Tassk>
           {
           };
                await tasks.AddRangeAsync(initialTasks);
                await SaveChangesAsync();
            }
        }

        public async Task AddNewTask(string name, string description)
        {
            var task = new Tassk(name, description);
            // Добавляем задачу в базу данных
            tasks.Add(task);
            await SaveChangesAsync();
        }

        public async Task AddNewResponsable(string name, string responsable)
        {
            
            using (var db = new SqliteConnection("Data Source=C:\\Users\\ovtch\\Downloads\\sqlite-tools-win-x64-3470000\\tasks.db"))
            {
                await db.OpenAsync();

                var command = new SqliteCommand("UPDATE Tasks SET Responsible = @responsable WHERE Title = @name", db);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@responsable", responsable);

                var result = command.ExecuteScalar();
            }

            //FindTask(name).responsible = responsable;
            await SaveChangesAsync();
        }

        public async Task MakeDone(string name)
        {
            using (var db = new SqliteConnection("Data Source=C:\\Users\\ovtch\\Downloads\\sqlite-tools-win-x64-3470000\\tasks.db"))
            {
                await db.OpenAsync();

                var command = new SqliteCommand("UPDATE Tasks SET \tIsCompleted = @responsable WHERE Title = @name", db);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@responsable", true);

                var result = command.ExecuteScalar();
            }
            await SaveChangesAsync();
        }

        public async Task GiveInformarion(string name)
        {
            using (var db = new SqliteConnection("Data Source=C:\\Users\\ovtch\\Downloads\\sqlite-tools-win-x64-3470000\\tasks.db"))
            {
                await db.OpenAsync();

                var command = new SqliteCommand("SELECT * FROM Tasks WHERE Title = @name", db);
                command.Parameters.AddWithValue("@name", name);

                //var result = command.ExecuteReader();

                using (var result = await command.ExecuteReaderAsync())
                {
                    await result.ReadAsync();
                    new Tassk(result["Title"].ToString(),
                        result["Description"].ToString(),
                        Int32.Parse(result["IsCompleted"].ToString()) == 1,
                        result["Responsible"].ToString()
                        ).GiveInformarion();
                }
            }
        }

        public int TaskCount()
        {
            return tasks.Count();
        }

        public int FindTask(string name)
        {
            using (var db = new SqliteConnection("Data Source=C:\\Users\\ovtch\\Downloads\\sqlite-tools-win-x64-3470000\\tasks.db"))
            {
                db.Open();
                var query = "SELECT Id FROM tasks WHERE Title = @Title";
                var command = new SqliteCommand(query, db);
                command.Parameters.AddWithValue("@Title", name);

                var result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1; // Возвращает Id или null, если не найдено
            }
        }


        ////////
        Task ITaskCollection.ToFile()
        {
            return null;
        }

        Task ITaskCollection.FromFile()
        {
            return null;
        }
    }
}