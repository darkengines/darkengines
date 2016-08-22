using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DarkEngines.Server {
    public static class ActionContextRepositoryExtensions {
        public static IServiceCollection AddActionContextRepository(this IServiceCollection serviceCollection) {
           return serviceCollection.AddSingleton<ActionContextRepository>();
        }
    }
    public class ActionContextRepository {
        private Dictionary<string, ActionContext> ActionContexts { get; }
		protected IEnumerable<IService> Services { get; }

		public ActionContextRepository(IEnumerable<IService> services) {
			Services = services;
            ActionContexts = services.SelectMany(CreateActionContexts)
            .ToDictionary(actionContext => actionContext.Key, actionContext => actionContext);
        }
        private IEnumerable<ActionContext> CreateActionContexts(IService service) {
            return service.GetType().GetMethods().Select(methodInfo => CreateActionContext(service, methodInfo));
        }
        private ActionContext CreateActionContext(IService service, MethodInfo methodInfo) {
            return new ActionContext(service, methodInfo);
        }
        public ActionContext GetActionContext(IManagedServicePayload managedServicePayload) {
            return ActionContexts[managedServicePayload.Key];
        }
    }
}
