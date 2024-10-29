
using System.Threading.Tasks;

namespace Storage
{
    public interface ITaskCollection
    {
        void AddNewTask(string name, string deskription);

        void AddNewResponsable(string name, string responsable);

        void MakeDone(string name);
        void GiveInformarion(string name);
        System.Threading.Tasks.Task ToFile();
        System.Threading.Tasks.Task FromFile();
        int TaskCount();
        int FindTask(string name);

    }
}
