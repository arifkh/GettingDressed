using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GettingReady.Model;

namespace GettingReady.Commands
{
    public class Headwear : ICommand
    {
        public string Print(Mode mode)
        {
            return mode == Mode.Hot ? "sunglasses" : "hat";
        }

        public bool CanPrint(Mode mode)
        {
            return true;
        }
    }
}
