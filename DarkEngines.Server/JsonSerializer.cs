using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkEngines.Server {
    public static class JsonSerializerExtensions {
        public static IServiceCollection AddJsonSerializer(this IServiceCollection serviceCollection) {
            return serviceCollection.AddSingleton<JsonSerializer>();
        }
    }
    public class JsonSerializer : ISerializer {
        public string ContentType { get { return "application/json"; } }
        public object Deserialize(string @string, Type type) {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(@string, type);
        }
        public T Deserialize<T>(string @string) {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(@string);
        }
        public string Serialize(object @object) {
            return Newtonsoft.Json.JsonConvert.SerializeObject(@object);
        }
    }
}
