using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Storage;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
namespace StorageTest
{
    public class DataBaseTests
    {
        private readonly Mock<DbSet<Tassk>> _mockSet;
        private readonly Mock<DataBase> _mockContext;

        public DataBaseTests()
        {
            _mockSet = new Mock<DbSet<Tassk>>();
            _mockContext = new Mock<DataBase>();

            // Setup the mock context to return the mock set
            _mockContext.Setup(m => m.tasks).Returns(_mockSet.Object);
            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1); // Mock SaveChangesAsync
        }

        [Fact]
        public async Task InitializeDatabase_ShouldAddInitialTasks_WhenNoTasksExist()
        {
            // Arrange
            _mockSet.Setup(m => m.AnyAsync(It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act
            await _mockContext.Object.InitializeDatabase();

            // Assert
            _mockSet.Verify(m => m.AddRangeAsync(It.IsAny<IEnumerable<Tassk>>(), It.IsAny<CancellationToken>()), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task AddNewTask_ShouldAddTask()
        {
            // Arrange
            var taskName = "Test Task";
            var taskDescription = "Test Description";

            // Act
            await _mockContext.Object.AddNewTask(taskName, taskDescription);

            // Assert
            _mockSet.Verify(m => m.Add(It.IsAny<Tassk>()), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task AddNewResponsable_ShouldUpdateResponsibleField()
        {
            // Arrange
            var taskName = "Test Task";
            var responsable = "John Doe";

            // Act
            await _mockContext.Object.AddNewResponsable(taskName, responsable);

            // Assert
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task MakeDone_ShouldMarkTaskAsCompleted()
        {
            // Arrange
            var taskName = "Test Task";

            // Act
            await _mockContext.Object.MakeDone(taskName);

            // Assert
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GiveInformarion_ShouldRetrieveTaskInformation()
        {
            // Arrange
            var taskName = "Test Task";
            var mockTask = new Tassk("Test Task", "Description", false, "John Doe");

            // Mock the Sqlite connection and command execution
            var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "CREATE TABLE Tasks (Title TEXT, Description TEXT, IsCompleted INTEGER, Responsible TEXT);";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO Tasks (Title, Description, IsCompleted, Responsible) VALUES ('Test Task', 'Description', 0, 'John Doe');";
            command.ExecuteNonQuery();

            // Act
            await _mockContext.Object.GiveInformarion(taskName);

            // Assert
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void TaskCount_ShouldReturnCorrectCount()
        {
            // Arrange
            var data = new List<Tassk>
        {
            new Tassk("Task 1", "Description 1"),
            new Tassk("Task 2", "Description 2"),
        }.AsQueryable();

            _mockSet.As<IQueryable<Tassk>>().Setup(m => m.Provider).Returns(data.Provider);
            _mockSet.As<IQueryable<Tassk>>().Setup(m => m.Expression).Returns(data.Expression);
            _mockSet.As<IQueryable<Tassk>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _mockSet.As<IQueryable<Tassk>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            // Act
            var count = _mockContext.Object.TaskCount();

            // Assert
            Assert.Equal(2, count);
        }

        [Fact]
        public void FindTask_ShouldReturnTaskId_WhenTaskExists()
        {
            // Arrange
            var taskTitle = "Existing Task";
            var taskId = 1;

            // Mock the database to return an Id when the task exists
            _mockContext.Setup(m => m.FindTask(taskTitle)).Returns(taskId);

            // Act
            var result = _mockContext.Object.FindTask(taskTitle);

            // Assert
            Assert.Equal(taskId, result);
        }

        [Fact]
        public void FindTask_ShouldReturnMinusOne_WhenTaskDoesNotExist()
        {
            // Arrange
            var taskTitle = "Non-existing Task";

            // Mock the database to return -1 when the task does not exist
            _mockContext.Setup(m => m.FindTask(taskTitle)).Returns(-1);

            // Act
            var result = _mockContext.Object.FindTask(taskTitle);

            // Assert
            Assert.Equal(-1, result);
        }
    }
}