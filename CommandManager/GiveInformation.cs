using Storage;
namespace CommandManager
{
    public class GiveInformation : ICommand
    {
        public ITaskCollection collection;
        public GiveInformation(ITaskCollection collection)
        {
            this.collection = collection;
        }
        public bool IsMyTask(string taskName)
        {
            return collection.FindTask(taskName) != -1;
        }
        public string Name()
        {
            return ("GiveInformation");
        }
        public string Do(string name, string name2)
        {
            if (!IsMyTask(name))
            {
                return "Такой задачи нет";
            }
            else
            {
                collection.GiveInformarion(name);
                return " ";
            }
        }
    }
}
