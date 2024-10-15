using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
namespace Storage
{
    public class TaskCollection : ITaskCollection
    {
        private static List<Task> tasks;
        public TaskCollection()
        {
            tasks = new List<Task>();
            //while (tasks.Count > 0)
              //  Console.WriteLine(tasks[1]);
        }
        public int FindTask(string name)
        {
            int i = 0;
            for (; i < tasks.Count(); i++)
            {
                if (String.Equals(tasks[i].name, name))
                    break;
            }

            return i != tasks.Count() ? i : -1;
        }
        public void AddNewTask(string name, string deskription)
        {
            tasks.Add(new Task(name, deskription));
        }
        public void AddNewResponsable(string name, string responsible)
        {
            tasks[FindTask(name)].responsible = responsible;
        }
        public void MakeDone(string name)
        {
            tasks[FindTask(name)].state = true;
        }
        public void GiveInformarion(string name)
        {
            tasks[FindTask(name)].GiveInformarion();
        }
        public void ToFile()
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("tasks.json", json);
            Console.WriteLine("Задачи сохранены в файл tasks.json.");
        }

    }
}
