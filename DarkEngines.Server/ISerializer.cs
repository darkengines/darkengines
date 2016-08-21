using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkEngines.Server {
    public interface ISerializer {
        string Serialize(object @object);
        T Deserialize<T>(string @string);
        object Deserialize(string @string, Type type);
        string ContentType { get; }
    }
}
