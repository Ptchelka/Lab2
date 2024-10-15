using Storage;
namespace CommandManager
{
    internal class AddNewResponsable : ICommand
    {
        public ITaskCollection collection;
        public AddNewResponsable(ITaskCollection collection)
        {
            this.collection = collection;
        }
        public bool IsMyTask(string taskName)
        {
            return collection.FindTask(taskName) != -1;
        }
        public string Name()
        {
            return ("AddNewResponsable");
        }
        public void Do(string name, string responsable)
        {
            if (!IsMyTask(name))
            {
                Console.WriteLine("Такой задачи нет");
            }
            else
            {
                collection.AddNewResponsable(name, responsable);
            }
        }
    }
}
