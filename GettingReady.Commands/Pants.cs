using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GettingReady.Model;

namespace GettingReady.Commands
{
    public class Pants : ICommand
    {
        public string Print(Mode mode)
        {
            return mode == Mode.Hot ? "shorts" : "pants";
        }

        public bool CanPrint(Mode mode)
        {
            return true;
        }
    }
}
