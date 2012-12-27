using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GettingReady.Model;
using Microsoft.Practices.Unity;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public sealed class CommandProcessor : ICommandProcessor
    {
        private readonly UnityContainer _container;
        private readonly IDataRepository _repository;
        private readonly Dictionary<string, object> _commandsAlreadyRun = new Dictionary<string, object>();

        public CommandProcessor(IDataRepository repository, UnityContainer container)
        {
            _repository = repository;
            _container = container;
        }

        public void RegisterDependency(int keyCode, string commandName, string commandTypeName, IEnumerable<string> previousCommandNames)
        {
            _repository.RegisterCommand(keyCode, new CommandInfo
                                       {
                                           Name = commandName,
                                           TypeName = commandTypeName,
                                           PreviousCommandNames = previousCommandNames
                                       });

            _container.RegisterType(typeof(ICommand), Type.GetType(commandTypeName), commandName,
                new TransientLifetimeManager(),
                new InjectionMember[] { });
        }

        public string Print(int keyCode, Mode mode)
        {
            var commandInfo = _repository.GetCommand(keyCode);
            if (!CanPrint(commandInfo, mode)) throw new CannotPrintException();
            try
            {   
                var command = _container.Resolve<ICommand>(commandInfo.Name);
                return command.Print(mode);
            }
            finally
            {
                _commandsAlreadyRun[commandInfo.Name] = commandInfo;
            }
        }

        public void ClearCommandRunHistory()
        {
            _commandsAlreadyRun.Clear();
        }

        private bool CanPrint(CommandInfo commandInfo, Mode mode)
        {
            var previousCommands = new List<String>();
            foreach (var previousCommand in commandInfo.PreviousCommandNames)
            {
                var command = _container.Resolve<ICommand>(previousCommand);
                if (command.CanPrint(mode)) previousCommands.Add(previousCommand);
            }

            return previousCommands.Where(x => !_commandsAlreadyRun.ContainsKey(x)).Count() == 0;
        }
    }
}
