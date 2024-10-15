using Storage;
namespace CommandManager
{
    internal class GiveInformation : ICommand
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
            return ("GiveIbformation");
        }
        public void Do(string name, string name2)
        {
            if (!IsMyTask(name))
            {
                Console.WriteLine("Такой задачи нет");
            }
            else
            {
                collection.GiveInformarion(name);
            }
        }
    }
}
