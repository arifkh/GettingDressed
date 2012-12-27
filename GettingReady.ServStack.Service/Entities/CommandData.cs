using GettingReady.Model;
using ServiceStack.DataAnnotations;

namespace GettingReady.ServStack.Service
{
    public class CommandData
    {
        [PrimaryKey]
        public int Id { get; set; }

        public CommandInfo CommandInfo { get; set; }
    }
}
