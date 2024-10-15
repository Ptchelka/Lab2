using Storage;
namespace CommandManager
{
    internal class AddNewTask : ICommand
    {
        public ITaskCollection collection;
        public AddNewTask(ITaskCollection collection)
        {
            this.collection = collection;
        }
        public bool IsMyTask(string taskName)
        {
            return (collection.FindTask(taskName) != -1);
        }
        public string Name()
        {
            return ("AddNewTask");
        }
        public void Do(string name, string deskription)
        {
            if (IsMyTask(name))
            {
                Console.WriteLine("Такая задача уже есть");
            }
            else
            {
                collection.AddNewTask(name, deskription);
            }
        }
    }
}
