using Storage;
using System.Xml.Linq;
namespace CommandManager
{
    public class MakeDone : ICommand
    {
        public ITaskCollection collection;
        public MakeDone(ITaskCollection collection)
        {
            this.collection = collection;
        }
        public bool IsMyTask(string taskName)
        {
            return collection.FindTask(taskName) != -1;
        }
        public string Name()
        {
            return ("MakeDone");
        }
        public string Do(string name, string name2)
        {
            if (!IsMyTask(name))
            {
                return "Такой задачи нет";
            }
            else
            {
                collection.MakeDone(name);
                return "Задача выполнена!";
            }
        }
    }
}
