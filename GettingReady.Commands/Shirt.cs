using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GettingReady.Model;

namespace GettingReady.Commands
{
    public class Shirt : ICommand
    {
        public string Print(Mode mode)
        {
            return "shirt";
        }

        public bool CanPrint(Mode mode)
        {
            return true;
        }
    }
}
