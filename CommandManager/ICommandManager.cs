using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandManager
{
    public interface ICommandManager
    {
        void AddNewTask(string name, string deskription);
        void AddNewResponsable(string name, string responsable);
        void MakeDone(string name);
        void GiveInformation(string name);
        void ToFile();
    }
}
