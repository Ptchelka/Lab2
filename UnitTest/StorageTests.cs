using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Storage;


namespace StorageTests
{
    public class DataBaseTests
    {
        private DbContextOptions<DataBase> CreateNewContextOptions()
        {
            // —оздаЄм новый экземпл€р контекста базы данных с использованием InMemoryDatabase
            return new DbContextOptionsBuilder<DataBase>().UseInMemoryDatabase("TestDatabase").Options;
        }

        [Fact]
        public async Task AddNewTask_ShouldAddTaskToDatabase()
        {
            // Arrange
            var options = CreateNewContextOptions();

            using (var context = new DataBase(options))
            {
                var db = new DataBase(options);
                await db.InitializeDatabase();
                var taskName = "Test Task";
                var taskDescription = "This is a test task.";

                // Act
                await db.AddNewTask(taskName, taskDescription);
            }

            using (var context = new DataBase(options))
            {
                // Assert
                Assert.Equal(1, await context.tasks.CountAsync());
                var task = await context.tasks.FirstAsync();
                Assert.Equal("Test Task", task.title);
                Assert.Equal("This is a test task.", task.description);
            }
        }

        [Fact]
        public async Task MakeDone_ShouldMarkTaskAsCompleted()
        {
            // Arrange
            var options = CreateNewContextOptions();

            using (var context = new DataBase(options))
            {
                await context.AddNewTask("Test Task", "This is a test task.");
                await context.SaveChangesAsync();
            }

            using (var context = new DataBase(options))
            {
                // Act
                await context.MakeDone("Test Task");
            }

            using (var context = new DataBase(options))
            {
                // Assert
                var task = await context.tasks.FirstAsync();
                Assert.True(task.iscompleted);
            }
        }

        [Fact]
        public async Task AddNewResponsable_ShouldUpdateTaskResponsible()
        {
            // Arrange
            var options = CreateNewContextOptions();

            using (var context = new DataBase(options))
            {
                await context.AddNewTask("Test Task", "This is a test task.");
                await context.SaveChangesAsync();
            }

            using (var context = new DataBase(options))
            {
                // Act
                await context.AddNewResponsable("Test Task", "John Doe");
            }

            using (var context = new DataBase(options))
            {
                // Assert
                var task = await context.tasks.FirstAsync();
                Assert.Equal("John Doe", task.responsible);
            }
        }

        [Fact]
        public async Task TaskCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var options = CreateNewContextOptions();

            using (var context = new DataBase(options))
            {
                await context.AddNewTask("Test Task 1", "Description 1");
                await context.AddNewTask("Test Task 2", "Description 2");
                await context.SaveChangesAsync();
            }

            using (var context = new DataBase(options))
            {
                // Act
                var count = context.TaskCount();

                // Assert
                Assert.Equal(2, count);
            }
        }
    }
}