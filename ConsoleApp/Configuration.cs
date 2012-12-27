using System.Configuration;

namespace ConsoleApp
{
    public class GettingReadyConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("commands")]
        [ConfigurationCollection(typeof(CommandsCollection), AddItemName = "command")]
        public CommandsCollection Commands
        {
            get { return (CommandsCollection)this["commands"]; }
        }

        [ConfigurationProperty("repositories")]
        [ConfigurationCollection(typeof(RepositoriesCollection), AddItemName = "repository")]
        public RepositoriesCollection Repositories
        {
            get { return (RepositoriesCollection)this["repositories"]; }
        }
    }

    [ConfigurationCollection(typeof(CommandElement))]
    public class CommandsCollection : ConfigurationElementCollection
    {
        public CommandElement this[int index]
        {
            get { return (CommandElement)BaseGet(index); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new CommandElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CommandElement)element).Name;
        }
    }


    public class CommandElement : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true)]
        public int Key
        {
            get { return (int)this["key"]; }
        }

        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return this["name"].ToString(); }
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public string TypeFullName
        {
            get { return this["type"].ToString(); }
        }

        [ConfigurationProperty("previousCommands", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(PreviousCommandsCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public PreviousCommandsCollection PreviousCommands
        {
            get { return (PreviousCommandsCollection)base["previousCommands"]; }
        }
    }

    [ConfigurationCollection(typeof(PreviousCommandElement))]
    public class PreviousCommandsCollection : ConfigurationElementCollection
    {
        public PreviousCommandElement this[int index]
        {
            get { return (PreviousCommandElement)BaseGet(index); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new PreviousCommandElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PreviousCommandElement)element).Name;
        }
    }

    public class PreviousCommandElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return this["name"].ToString(); }
        }
    }


    #region Repositories

    [ConfigurationCollection(typeof(RepositoryElement))]
    public class RepositoriesCollection : ConfigurationElementCollection
    {
        [ConfigurationProperty("default", IsRequired=true)]
        public string DefaultRepositoryName
        {
            get { return this["default"].ToString(); }
        }

        public RepositoryElement this[int index]
        {
            get { return (RepositoryElement)BaseGet(index); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new RepositoryElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RepositoryElement)element).Name;
        }
    }

    public class RepositoryElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return this["name"].ToString(); }
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public string TypeFullName
        {
            get { return this["type"].ToString(); }
        }
    }

    #endregion
}
