using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Configuration;
using GettingReady.Core;
using Microsoft.Practices.Unity;
using GettingReady.Model;

namespace ConsoleApp
{
    class Program
    {
        static readonly UnityContainer Container = new UnityContainer();

        static void Main(string[] args)
        {
            var commandProcessor = RegisterDependencies();
            var commandText = String.Empty;
            do
            {
                commandProcessor.ClearCommandRunHistory();
                Console.WriteLine("\nEnter command");
                commandText = Console.ReadLine();
                var commandParser = new CommandParser(commandText);
                foreach (var keyCode in commandParser.Keys)
                {
                    try
                    {
                        Console.Write("{0}, ", commandProcessor.Print(keyCode, commandParser.CommandMode));
                    }
                    catch (CannotPrintException)
                    {
                        Console.WriteLine("failure");
                        break;
                    }
                }
            } while (!commandText.Equals("exit", StringComparison.InvariantCultureIgnoreCase));

        }

        static ICommandProcessor RegisterDependencies()
        {
            var configSection = ConfigurationManager.GetSection("GettingReady") as GettingReadyConfigurationSection;
            foreach (RepositoryElement repositoryElement in configSection.Repositories)
            {
                if (repositoryElement.Name == configSection.Repositories.DefaultRepositoryName)
                {
                    Container.RegisterType(typeof (IDataRepository), Type.GetType(repositoryElement.TypeFullName));
                    break;
                }
            }

            Container.RegisterType<ICommandProcessor, CommandProcessor>(new ContainerControlledLifetimeManager(),
                                                                        new InjectionConstructor(
                                                                            new object[]
                                                                                {
                                                                                    new ResolvedParameter<IDataRepository>(),
                                                                                    Container
                                                                                }
                                                                            ));

            var commandProcessor = Container.Resolve<ICommandProcessor>();

            var commands = configSection.Commands;

            foreach (CommandElement commandElement in commands)
            {
                var key = commandElement.Key;
                var name = commandElement.Name;
                var typeName = commandElement.TypeFullName;

                commandProcessor.RegisterDependency(key, name, typeName, commandElement.PreviousCommands.GetNames());
            }

            return commandProcessor;
        }
    }
}
