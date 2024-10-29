using CommandManager;
using IInterface;
using Storage;

namespace Programm
{

    internal class Programm
    {

        private static async System.Threading.Tasks.Task Run()
        {
            TaskCollection collection = new TaskCollection();
            Interface i = new Interface(new Manager(collection, new AddNewTask(collection),
                new AddNewResponsable(collection),new MakeDone(collection), 
                new GiveInformation(collection)));//конструктор с cm
            await i.Run();
        }

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            await Run();
        }
    }
}