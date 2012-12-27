using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GettingReady.Model
{
    public interface IDataRepository
    {
        void RegisterCommand(int keyCode, CommandInfo commandInfo);

        CommandInfo GetCommand(int keyCode);
    }
}
