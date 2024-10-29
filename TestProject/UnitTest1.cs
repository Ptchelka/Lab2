using System.Text.Json;
using NUnit.Framework.Internal;
using Storage;
namespace TestProject
{
    public class Tests
    {
        public class TaskCollectionTests : IDisposable
        {
            private const string TestFilePath = "test_tasks.json";
            private TaskCollection taskCollection;

            [SetUp]
            public void Setup()
            {
                taskCollection = new TaskCollection();
            }

            [Test]
            public void AddNewTask()
            {
                taskCollection.AddNewTask("Test Task", "Test Description");
                Assert.AreNotEqual(taskCollection.FindTask("Test Task"), -1);
            }
            [Test]
            public void FindTask_ReturnsCorrectIndex()
            {
                taskCollection.AddNewTask("Test Task", "Test Description");
                int index = taskCollection.FindTask("Test Task");
                Assert.GreaterOrEqual(index, 0);
            }

            [Test]
            public void AddNewResponsable_UpdatesResponsibleField()
            {
                taskCollection.AddNewTask("Test Task", "Test Description");
                taskCollection.AddNewResponsable("Test Task", "John Doe");
                Assert.AreEqual("John Doe", taskCollection.GetResponsible("Test Task"));
            }
            [Test]
            public void AddNewResponsable_ChangeResponsibleField()
            {
                taskCollection.AddNewTask("Test Task", "Test Description");
                taskCollection.AddNewResponsable("Test Task", "John Doe");
                taskCollection.AddNewResponsable("Test Task", "John Doe2");
                Assert.AreEqual("John Doe2", taskCollection.GetResponsible("Test Task"));
            }

            [Test]
            public void MakeDone_UpdatesStateField()
            {
                taskCollection.AddNewTask("Test Task", "Test Description");
                taskCollection.MakeDone("Test Task");
                Assert.AreEqual(true, taskCollection.GetState("Test Task"));
            }
            [Test]
            public void MakeDone_Updates2TimesStateField()
            {
                taskCollection.AddNewTask("Test Task", "Test Description");
                taskCollection.MakeDone("Test Task");
                taskCollection.MakeDone("Test Task");
                Assert.AreEqual(true, taskCollection.GetState("Test Task"));
            }

            [Test]
            public async System.Threading.Tasks.Task ToAndFromFileAsync()
            {
                taskCollection.AddNewTask("TestTask","TestDeskription");

                var json = JsonSerializer.Serialize(taskCollection, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(TestFilePath, json);

                taskCollection.FromFile();
                Assert.AreEqual(0, taskCollection.FindTask("TestTask"));
                Assert.AreEqual(1, taskCollection.TaskCount());
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