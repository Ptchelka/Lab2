using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using CommandManager;
using Storage;
namespace TestProject
{
    public class UnitTestComand
    {
        public class CommandManagerTests : IDisposable
        {
            private const string TestFilePath = "test_tasks.json";
            private Manager manager;

            [SetUp]
            public void Setup()
            {
                var collection = new TaskCollection();
                manager = new Manager(collection, new AddNewTask(collection),
                new AddNewResponsable(collection), new MakeDone(collection),
                new GiveInformation(collection));
            }

            [Test]
            public void AddNewTask_NotAddingDouble()
            {
                manager.AddNewTask("Test Task", "Test Description");
                manager.AddNewTask("Test Task", "Test Description");
                Assert.AreEqual(manager.TaskCount(), 1);
            }

            // Cleanup after tests
            public void Dispose()
            {
                if (File.Exists(TestFilePath))
                {
                    File.Delete(TestFilePath);
                }
            }
        }
    }
}