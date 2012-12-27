using System;
using ServiceStack.OrmLite;

namespace GettingReady.ServStack.Service
{
    public class CommandRepository
    {
        public IDbConnectionFactory DbConnectionFactory { get; set; }

        public bool AddCommand(CommandData data, out string errorMessage)
        {
            errorMessage = null;
            try
            {
                using (var db = DbConnectionFactory.OpenDbConnection())
                {
                    db.CreateTableIfNotExists<CommandData>();
                    db.Save(data);
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public CommandData GetCommand(int id)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                return db.FirstOrDefault<CommandData>(x => x.Id == id);
            }
        }
    }
}
