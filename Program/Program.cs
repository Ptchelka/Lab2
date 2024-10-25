using CommandManager;
using IInterface;
using Storage;
namespace Programm
{

    internal class Programm
    {

        private static void Run()
        {
            TaskCollection collection = new TaskCollection();
            Interface i = new Interface(new Manager(collection, new AddNewTask(collection),
                new AddNewResponsable(collection),new MakeDone(collection), 
                new GiveInformation(collection)));//конструктор с cm
            i.Run();
        }

        static void Main(string[] args)
        {
            Run();
        }
    }
}