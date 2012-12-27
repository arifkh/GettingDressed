using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GettingReady.Model;

namespace GettingReady.Commands
{
    public class LeaveHome : ICommand
    {
        public string Print(Mode mode)
        {
            return "leaving house";
        }

        public bool CanPrint(Mode mode)
        {
            return true;
        }
    }
}
