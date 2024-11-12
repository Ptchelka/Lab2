
using System.Threading.Tasks;

namespace Storage
{
    public interface ITaskCollection
    {
        Task AddNewTask(string name, string deskription);

        Task AddNewResponsable(string name, string responsable);
        Task MakeDone(string name);
        Task GiveInformarion(string name);
        System.Threading.Tasks.Task ToFile();
        System.Threading.Tasks.Task FromFile();
        int TaskCount();
        int FindTask(string name);

    }
}
