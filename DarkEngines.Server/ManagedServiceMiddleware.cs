using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkEngines.Server {
    public static class ManagedServiceMiddlewareExtensions {
        public static IApplicationBuilder UseManagedServiceMiddleware(this IApplicationBuilder applicationBuilder) {
            return applicationBuilder.UseMiddleware<ManagedServiceMiddleware>();
        }
    }
    public class ManagedServiceMiddleware {
        protected HttpManagedServiceRequestHandler HttpManagedServiceRequestHandler { get; }
        public ManagedServiceMiddleware(RequestDelegate next, HttpManagedServiceRequestHandler httpManagedServiceRequestHandler) {
            HttpManagedServiceRequestHandler = httpManagedServiceRequestHandler;
        }
        public async Task Invoke(HttpContext httpContext) {
            await HttpManagedServiceRequestHandler.Process(httpContext);
        }
    }
}
