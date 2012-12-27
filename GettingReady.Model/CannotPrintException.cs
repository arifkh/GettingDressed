using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GettingReady.Model
{
    public class CannotPrintException : Exception
    {
        public CannotPrintException():base()
        {
            
        }

        public CannotPrintException(string message):base(message)
        {
            
        }
    }
}
