using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;

namespace DarkEngines.Server {
    public interface IManagedServiceRequestHandler {
        Task Process(object context);
    }
}
