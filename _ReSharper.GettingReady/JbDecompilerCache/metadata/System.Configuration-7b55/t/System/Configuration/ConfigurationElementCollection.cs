// Type: System.Configuration.ConfigurationElementCollection
// Assembly: System.Configuration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Configuration.dll

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime;
using System.Xml;

namespace System.Configuration
{
    [DebuggerDisplay("Count = {Count}")]
    public abstract class ConfigurationElementCollection : ConfigurationElement, ICollection, IEnumerable
    {
        protected ConfigurationElementCollection();
        protected ConfigurationElementCollection(IComparer comparer);

        protected internal string AddElementName { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; set; }

        protected internal string RemoveElementName { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; set; }

        protected internal string ClearElementName { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; set; }

        public bool EmitClear { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; set; }

        protected virtual string ElementName { get; }
        protected virtual bool ThrowOnDuplicate { get; }
        public virtual ConfigurationElementCollectionType CollectionType { get; }

        #region ICollection Members

        void ICollection.CopyTo(Array arr, int index);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public IEnumerator GetEnumerator();

        public int Count { get; }
        public bool IsSynchronized { get; }
        public object SyncRoot { get; }

        #endregion

        protected internal override bool IsModified();
        protected internal override void ResetModified();
        public override bool IsReadOnly();
        protected internal override void SetReadOnly();
        public override bool Equals(object compareTo);
        public override int GetHashCode();
        protected internal override void Unmerge(ConfigurationElement sourceElement, ConfigurationElement parentElement, ConfigurationSaveMode saveMode);
        protected internal override void Reset(ConfigurationElement parentElement);
        public void CopyTo(ConfigurationElement[] array, int index);

        protected virtual void BaseAdd(ConfigurationElement element);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        protected internal void BaseAdd(ConfigurationElement element, bool throwIfExists);

        protected int BaseIndexOf(ConfigurationElement element);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        protected virtual void BaseAdd(int index, ConfigurationElement element);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        protected internal void BaseRemove(object key);

        protected internal ConfigurationElement BaseGet(object key);
        protected internal bool BaseIsRemoved(object key);
        protected internal ConfigurationElement BaseGet(int index);
        protected internal object[] BaseGetAllKeys();
        protected internal object BaseGetKey(int index);
        protected internal void BaseClear();
        protected internal void BaseRemoveAt(int index);
        protected internal override bool SerializeElement(XmlWriter writer, bool serializeCollectionKey);
        protected override bool OnDeserializeUnrecognizedElement(string elementName, XmlReader reader);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        protected virtual ConfigurationElement CreateNewElement(string elementName);

        protected abstract ConfigurationElement CreateNewElement();
        protected abstract object GetElementKey(ConfigurationElement element);
        protected virtual bool IsElementRemovable(ConfigurationElement element);
        protected virtual bool IsElementName(string elementName);
    }
}
