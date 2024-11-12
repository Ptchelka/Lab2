using CommandManager;
using IInterface;
using Storage;

namespace Programm
{

    internal class Programm
    {

        private static async System.Threading.Tasks.Task Run()
        {
            ITaskCollection collection = new DataBase();
            Interface i = new Interface(new Manager(collection, new AddNewTask(collection),
                new AddNewResponsable(collection),new MakeDone(collection), 
                new GiveInformation(collection)));//конструктор с cm
            // await using ()
            await using (var context = new DataBase())
            {
                context.InitializeDatabase();
            }
            await i.Run();
        }

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            await Run();
        }
    }
}