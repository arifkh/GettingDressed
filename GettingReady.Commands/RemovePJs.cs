using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GettingReady.Model;

namespace GettingReady.Commands
{
    public class RemovePJs : ICommand
    {
        public string Print(Mode mode)
        {
            return "Removing PJs";
        }

        public bool CanPrint(Mode mode)
        {
            return true;
        }
    }
}
