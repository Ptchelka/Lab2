using CommandManager;
using Storage;
namespace IInterface
{
    public class Interface
    {
        private ICommandManager commandmanager;
        public Interface(ICommandManager cm)
        {
            commandmanager = cm;
        }
        public void Run()
        {

            Console.WriteLine("Меню:\r\n1. Добавить новую задачу\r\n" +
                                "2. Назначить ответственного за задачу\r\n" +
                                "3. Отметить задачу как выполненную\r\n" +
                                "4. Вывести информацию о задаче по назваию\r\n" +
                                "5. Выйти из программы\r\n");
            bool f = true;
            while (f)
            {
                Console.WriteLine("Выберите действие (1-4)");
                string a = Console.ReadLine();
                Console.WriteLine("Введите название задачи");
                string maasage = Console.ReadLine();

                switch (a)
                {
                    case "1":
                        Console.WriteLine("Введите описание");
                        commandmanager.AddNewTask(maasage, Console.ReadLine());
                        break;
                    case "2":
                        Console.WriteLine("Введите ответсвенного");
                        commandmanager.AddNewResponsable(maasage, Console.ReadLine());
                        break;
                    case "3":
                        //Console.WriteLine("Введите название задачи");
                        commandmanager.MakeDone(maasage);
                        break;
                    case "4":
                        //Console.WriteLine("Введите название задачи");
                        commandmanager.GiveInformation(maasage);
                        break;
                    case "5":
                        commandmanager.ToFile();
                        f = false;
                        break;
                    default:
                        Console.WriteLine("Вы ввели несуществующее действие");
                        break;

                }
            }
        }
    }
}
