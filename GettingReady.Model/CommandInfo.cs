using System.Collections.Generic;
namespace GettingReady.Model
{
    public class CommandInfo
    {
        public string Name { get; set; }

        public string TypeName { get; set; }

        public IEnumerable<string> PreviousCommandNames { get; set; }
    }
}
