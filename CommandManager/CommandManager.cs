using Storage;
using System.Xml.Linq;
namespace CommandManager
{
    public class Manager : ICommandManager
    {
        private ICommand addNewTask;
        private ICommand addNewResponsable;
        private ICommand makeDone;
        private ICommand giveInformation;
        public ITaskCollection collection;
        public Manager()
        {
            
            collection = new TaskCollection();
            addNewTask = new AddNewTask(collection);
            addNewResponsable = new AddNewResponsable(collection);
            makeDone = new MakeDone(collection);
            giveInformation = new GiveInformation(collection);
        }
        public void AddNewTask(string name, string deskription)
        {
            addNewTask.Do(name, deskription);
        }
        public void AddNewResponsable(string name, string responsable)
        {
            addNewResponsable.Do(name, responsable);
        }
        public void MakeDone(string name)
        {
            makeDone.Do(name, name);
        }
        public void GiveInformation(string name)
        {
            giveInformation.Do(name, name);
        }
        public void ToFile()
        {
            collection.ToFile();
        }
    }
}
