using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GettingReady.Model;

namespace GettingReady.Commands
{
    public class Socks : ICommand
    {
        public string Print(Mode mode)
        {
            return mode == Mode.Hot ? "fail" : "socks";
        }

        public bool CanPrint(Mode mode)
        {
            return mode == Mode.Cold;
        }
    }
}
