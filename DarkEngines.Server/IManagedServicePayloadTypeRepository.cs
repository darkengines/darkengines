using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkEngines.Server {
    public interface IManagedServicePayloadTypeRepository {
        string ContentType { get; }
        Type ManagedServicePayloadType { get; }
    }

	public static class JsonManagedServicePayloadTypeExtensions
	{
		public static IServiceCollection AddJsonManagedServicePayloadType(this IServiceCollection serviceCollection)
		{
			return serviceCollection.AddSingleton<IManagedServicePayloadTypeRepository, JsonManagedServicePayloadType>();
		}
	}

	public class JsonManagedServicePayloadType : IManagedServicePayloadTypeRepository {
        public string ContentType { get { return "application/json"; } }
        public Type ManagedServicePayloadType { get { return typeof(JsonManagedServicePayload); } }
    }
}
