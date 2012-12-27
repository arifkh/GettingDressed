using System.Net;

namespace GettingReady.Model
{
    public class CommandResponse
    {
        public string Message { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}