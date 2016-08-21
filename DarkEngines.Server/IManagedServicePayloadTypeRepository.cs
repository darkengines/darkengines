using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkEngines.Server {
    public interface IManagedServicePayloadTypeRepository {
        string ContentType { get; }
        Type ManagedServicePayloadType { get; }
    }

    public class JsonManagedServicePayloadType : IManagedServicePayloadTypeRepository {
        public string ContentType { get { return "application/json"; } }
        public Type ManagedServicePayloadType { get { return typeof(JsonManagedServicePayload); } }
    }
}
