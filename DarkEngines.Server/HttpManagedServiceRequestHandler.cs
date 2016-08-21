using Microsoft.AspNetCore.Http;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace DarkEngines.Server {
    public static class HttpManagedServiceRequestHandlerExtensions {
        public static IServiceCollection AddHttpManagedServiceRequestHandler(this IServiceCollection serviceCollection) {
            return serviceCollection.AddSingleton<HttpManagedServiceRequestHandler>();
        }
    }
    public class HttpManagedServiceRequestHandler : ManagedServiceRequestHandler<HttpContext> {
        protected IServiceProvider ServiceProvider { get; }
        public HttpManagedServiceRequestHandler(ActionContextRepository actionContextRepository, IServiceProvider serviceProvider)
        : base(actionContextRepository) {
            ServiceProvider = serviceProvider;
        }

        protected async override Task<IManagedServicePayload> LoadPayload(HttpContext context) {
            var inputContentType = context.Request.ContentType;
            var inputSerializer = ServiceProvider.GetServices<ISerializer>()
            .First(serializer => serializer.ContentType.Equals(inputContentType, StringComparison.OrdinalIgnoreCase));

            using (var reader = new StreamReader(context.Request.Body)) {
                var content = await reader.ReadToEndAsync();
                var payloadType = ServiceProvider.GetServices<IManagedServicePayloadTypeRepository>()
                .First(provider => provider.ContentType == inputContentType).ManagedServicePayloadType;
                var payload = (IManagedServicePayload)inputSerializer.Deserialize(content, payloadType);
                return payload;
            }
        }

        protected async override Task WriteResponse(HttpContext context, object result) {
            var outputContentType = context.Request.Headers["accept"];
            var outputSerializer = ServiceProvider.GetServices<ISerializer>()
            .First(serializer => serializer.ContentType.Equals(outputContentType, StringComparison.OrdinalIgnoreCase));
            var serializedContent = outputSerializer.Serialize(result);

            context.Response.ContentType = outputContentType;
            await context.Response.WriteAsync(serializedContent);
        }
    }
}
