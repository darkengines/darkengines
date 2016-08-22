using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DarkEngines.Server {
    public interface IManagedServicePayload {
        string ServiceName { get; }
        string MethodName { get; }
        object[] GetParameters(ParameterInfo[] parameterInfos);
        string Key { get; }
    }

    public class JsonManagedServicePayload: IManagedServicePayload
	{
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public JToken Parameters { get; set; }
        public object[] GetParameters(ParameterInfo[] parameterInfos) {
            return parameterInfos.Join(
                Parameters.OfType<JProperty>(),
                parameterInfo => parameterInfo.Name,
                jsonProperty => jsonProperty.Name,
                (parameterInfo, jsonProperty) => jsonProperty.ToObject(parameterInfo.ParameterType)
            ).ToArray();
        }
        public string Key { get { return $"{ServiceName}.{MethodName}"; } }
        public override int GetHashCode() {
            return Key.GetHashCode();
        }
    }
}
