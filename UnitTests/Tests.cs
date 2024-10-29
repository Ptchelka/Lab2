using Storage;
using System.Text.Json;

namespace UnitTests
{
    public class Tests
    {
        private TaskCollection taskCollection;
        public Tests (TaskCollection taskCollection)
        {
            this.taskCollection = taskCollection;
            AddNewTask();
            FindTask();
            AddNewResponsable();
            MakeDone();
        }

        public void AddNewTask()
        {
            Console.WriteLine("\r\nдобавляем задачу  Test Task Test Description\r\n");
            taskCollection.AddNewTask("Test Task", "Test Description");
            taskCollection.GiveInformarion("Test Task");
        }

        public void FindTask()
        {
            Console.WriteLine("\r\nищем задачу  Test Task2 Test Description2\r\n");
            taskCollection.AddNewTask("Test Task2", "Test Description2");
            if (taskCollection.FindTask("Test Task2") != -1)
                Console.WriteLine("найдено\r\n");
            else
                Console.WriteLine("произошла ошибка\r\n");
        }
        public void AddNewResponsable()
        {
            Console.WriteLine("\r\nдобавляем задачу  Test Task3 и  Test Description3, добавляем ответсвенного John Doe\r\n");
            taskCollection.AddNewTask("Test Task3", "Test Description3");
            taskCollection.AddNewResponsable("Test Task3", "John Doe");
            taskCollection.GiveInformarion("Test Task3");
        }
        public void MakeDone()
        {
            Console.WriteLine("\r\nдобавляем задачу  Test Task4 и  Test Description4, отмечаем выполненной\r\n");
            taskCollection.AddNewTask("Test Task4", "Test Description4");
            taskCollection.MakeDone("Test Task4");
            taskCollection.GiveInformarion("Test Task4");
        }
    }
}
