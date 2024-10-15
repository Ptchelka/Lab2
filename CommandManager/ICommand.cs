using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandManager
{
    internal interface ICommand
    {
        void Do(string name, string name2);
        bool IsMyTask(string taskName);
        string Name();
    }
}
