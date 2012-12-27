using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GettingReady.Model;

namespace GettingReady.Commands
{
    public class Footwear : ICommand
    {
        public string Print(Mode mode)
        {
            return mode == Mode.Hot ? "sandals" : "boots";
        }

        public bool CanPrint(Mode mode)
        {
            return true;
        }
    }
}
