using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandManager
{
    public interface ICommandManager
    {
        ITaskCollection collection { get; }

        string AddNewTask(string name, string deskription);
        string AddNewResponsable(string name, string responsable);
        string MakeDone(string name);
        string GiveInformation(string name);
        void ToFile();
    }
}
