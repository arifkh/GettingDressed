using System.Collections.Generic;
using GettingReady.Model;

namespace GettingReady.Core
{
    public class InMemoryRepository : IDataRepository
    {
        private readonly Dictionary<int, CommandInfo> _commandInfos = new Dictionary<int, CommandInfo>();

        public void RegisterCommand(int keyCode, CommandInfo commandInfo)
        {
            _commandInfos.Add(keyCode, commandInfo);
        }

        public CommandInfo GetCommand(int keyCode)
        {
            return _commandInfos[keyCode];
        }
    }
}