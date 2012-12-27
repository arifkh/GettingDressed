using System;
using GettingReady.Model;
using ServiceStack.ServiceClient.Web;

namespace GettingReady.Core
{
    public class ServiceStackRepository : IDataRepository
    {
        private readonly ServiceClientBase _client = new JsonServiceClient("http://localhost:1337/");

        public void RegisterCommand(int keyCode, CommandInfo commandInfo)
        {
            var response = _client.Post<CommandResponse>(String.Format("command/{0}", keyCode), commandInfo);
        }

        public CommandInfo GetCommand(int keyCode)
        {
            var data = _client.Get<CommandInfo>(String.Format("command/{0}", keyCode));
            return data;
        }
    }
}
