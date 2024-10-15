using CommandManager;
using IInterface;
namespace Programm
{

    internal class Programm
    {

        private static void Run()
        {
            Interface i = new Interface(new Manager());//конструктор с cm
            i.Run();
        }

        static void Main(string[] args)
        {
            Run();
        }
    }
}