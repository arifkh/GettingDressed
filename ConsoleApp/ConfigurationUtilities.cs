using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    public static class ConfigurationUtilities
    {
        public static IEnumerable<string> GetNames(this PreviousCommandsCollection commandsCollection)
        {
            foreach (PreviousCommandElement prevCommandElement in commandsCollection)
            {
                yield return prevCommandElement.Name;
            }
        }
    }
}
