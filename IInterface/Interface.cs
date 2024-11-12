using CommandManager;
using Storage;
using System.Diagnostics.CodeAnalysis;
namespace IInterface
{
    [ExcludeFromCodeCoverage]
    public class Interface
    {
        private ICommandManager commandmanager;
        public Interface(Manager cm)
        {
            commandmanager = cm;
        }
        public async System.Threading.Tasks.Task Run()
        {
            //await commandmanager.FromFile();
            Console.WriteLine("Меню:\r\n1. Добавить новую задачу\r\n" +
                                "2. Назначить ответственного за задачу\r\n" +
                                "3. Отметить задачу как выполненную\r\n" +
                                "4. Вывести информацию о задаче по назваию\r\n");
            bool continues = true;
            while (continues)
            {
                Console.WriteLine("Выберите действие (1-4)");
                string a = Console.ReadLine();
                Console.WriteLine("Введите название задачи");
                string maasage = Console.ReadLine();

                switch (a)
                {
                    case "1":
                        Console.WriteLine("Введите описание");
                        Console.WriteLine(commandmanager.AddNewTask(maasage, Console.ReadLine()));
                        
                        break;
                    case "2":
                        Console.WriteLine("Введите ответсвенного");
                        Console.WriteLine(commandmanager.AddNewResponsable(maasage, Console.ReadLine()));
                        break;
                    case "3":
                        Console.WriteLine(commandmanager.MakeDone(maasage));
                        break;
                    case "4":
                        Console.WriteLine(commandmanager.GiveInformation(maasage));
                        break;
                    default:
                        Console.WriteLine("Вы ввели несуществующее действие");
                        break;

                }
            }
        }
    }
}
