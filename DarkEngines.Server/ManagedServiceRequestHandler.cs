using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DarkEngines.Server {
    public abstract class ManagedServiceRequestHandler<TContext> : IManagedServiceRequestHandler {
        protected ActionContextRepository ActionContextRepository { get; }
        public ManagedServiceRequestHandler(ActionContextRepository actionContextRepository) {
            ActionContextRepository = actionContextRepository;
        }

        protected abstract Task<IManagedServicePayload> LoadPayload(TContext context);
        protected abstract Task WriteResponse(TContext context, object result);

        public async Task Process(TContext context) {
            var payload = await LoadPayload(context);
            var actionContext = ActionContextRepository.GetActionContext(payload);
            var parameters = payload.GetParameters(actionContext.ParameterInfos);
            var result = await actionContext.Invoke(parameters);
            await WriteResponse(context, result);
        }

        async Task IManagedServiceRequestHandler.Process(object context) { await Process((TContext)context); }
    }
}
