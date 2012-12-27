// Type: ServiceStack.ServiceClient.Web.JsonServiceClient
// Assembly: ServiceStack.Common, Version=3.9.32.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\dev\Prototypes\GettingReady\packages\ServiceStack.Common.3.9.32\lib\net35\ServiceStack.Common.dll

using ServiceStack.ServiceHost;
using System.IO;

namespace ServiceStack.ServiceClient.Web
{
    public class JsonServiceClient : ServiceClientBase
    {
        public JsonServiceClient();
        public JsonServiceClient(string baseUri);
        public JsonServiceClient(string syncReplyBaseUri, string asyncOneWayBaseUri);
        public override string Format { get; }
        public override string ContentType { get; }
        public override StreamDeserializerDelegate StreamDeserializer { get; }
        public override void SerializeToStream(IRequestContext requestContext, object request, Stream stream);
        public override T DeserializeFromStream<T>(Stream stream);
    }
}
