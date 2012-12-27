namespace ConsoleApp
{
    interface ICommandProcessor
    {
        void ClearCommandRunHistory();
        string Print(int keyCode, GettingReady.Model.Mode mode);
        void RegisterDependency(int keyCode, string commandName, string commandTypeName, System.Collections.Generic.IEnumerable<string> previousCommandNames);
    }
}
