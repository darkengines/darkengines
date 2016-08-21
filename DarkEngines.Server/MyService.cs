using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkEngines.Server {
    public static class MyServiceExtension {
        public static IServiceCollection AddMyService(this IServiceCollection serviceCollection) {
            return serviceCollection.AddSingleton<IService, MyService>();
        }
    }
    public class MyService : IService {
        public int Add(int a, int b) { return a + b; }
    }
}
