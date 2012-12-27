using System.Net;
using GettingReady.Model;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using ServiceStack.WebHost.Endpoints;

namespace GettingReady.ServStack.Service
{
    public class CommandService : ServiceStack.ServiceInterface.Service
    {
        public CommandRepository Repository { get; set; }

        public CommandResponse Post(CommandEntry entry)
        {
            string errMsg;
            var success = Repository.AddCommand(new CommandData() { Id = entry.Id, CommandInfo = entry }, out errMsg);
            var response = new CommandResponse()
                               {
                                   Status = success ? HttpStatusCode.Created : HttpStatusCode.InternalServerError,
                                   Message = errMsg
                               };
            return response;
        }

        public CommandInfo Get(CommandQuery query)
        {
            var data = Repository.GetCommand(query.Id);
            return data == null ? null : data.CommandInfo;
        }
    }


    public class AppHost : AppHostHttpListenerBase
    {
        public AppHost() : base("Command Service", typeof(CommandService).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            RegisterRoutes();
            RegisterDependencies(container);
        }

        private void RegisterRoutes()
        {
            Routes
                .Add<CommandEntry>("/command/{Id}", ApplyTo.Post)
                .Add<CommandQuery>("/command/{Id}", ApplyTo.Get);
        }

        private void RegisterDependencies(Funq.Container container)
        {
            var ormLiteConnectionFactory =
                new OrmLiteConnectionFactory(System.IO.Path.GetFullPath("~/../../../App_Data/data.db"), SqliteDialect.Provider);


            container.Register<IDbConnectionFactory>(ormLiteConnectionFactory);
            container.RegisterAutoWired<CommandRepository>();
        }
    }
}