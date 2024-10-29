using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System;
using System.Threading.Tasks;
namespace Storage
{
    public class TaskCollection : ITaskCollection
    {
        private const string TasksJson = "tasks.json";
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
        public string GetResponsible(string name)
        {
            return tasks[FindTask(name)].responsible;
        }
        public bool GetState(string name)
        {
            return tasks[FindTask(name)].state;
        }
        public int TaskCount()
        {
            return tasks.Count;
        }
        /*
        public void FromFile()
        {
            string jsonString = File.ReadAllText(TasksJson);
            tasks = JsonSerializer.Deserialize<List<Task>>(jsonString)!;
        }
        public void ToFile()
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(TasksJson, json);
        }
        */
        public async System.Threading.Tasks.Task FromFile()
        {
            using (StreamReader reader = new StreamReader(TasksJson))
            {
                string jsonString = await reader.ReadToEndAsync();
                tasks = JsonSerializer.Deserialize<List<Task>>(jsonString)!;
            }
        }

        public async System.Threading.Tasks.Task ToFile()
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            using (StreamWriter writer = new StreamWriter(TasksJson))
            {
                await writer.WriteAsync(json);
            }
        }
    }
}
