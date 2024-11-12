using Storage;
namespace CommandManager
{
    public class AddNewTask : ICommand
    {
        public ITaskCollection collection;
        public AddNewTask(ITaskCollection collection)
        {
            this.collection = collection;
        }
        public bool IsMyTask(string taskName)
        {
            //Console.WriteLine(collection.TaskCount() + " " + taskName);
            return (collection.FindTask(taskName) != -1);
        }
        public string Name()
        {
            return ("AddNewTask");
        }
        public string Do(string name, string deskription)
        {
            if (IsMyTask(name))
            {
                return "Такая задача уже есть";
            }
            else
            {
                collection.AddNewTask(name, deskription);
                return "Добавлено";
            }
        }
    }
}
