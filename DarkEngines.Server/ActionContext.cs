using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Expressions;

namespace DarkEngines.Server {
    public class ActionContext {
        protected IService Service { get; }
        protected Func<object, object[], object> Delegate { get; }

        public string Key { get; }
        public ParameterInfo[] ParameterInfos { get; }

        public async Task<object> Invoke(object[] parameters) {
            return Delegate(Service, parameters);
        }

        public ActionContext(IService service, MethodInfo methodInfo) {
            Service = service;
			var serviceType = service.GetType();
			Key = $"{serviceType.FullName}.{methodInfo.Name}";

            ParameterInfos = methodInfo.GetParameters();
            var orderedParameterTypes = ParameterInfos.Select(parameterInfo => parameterInfo.ParameterType).ToArray();

            var serviceInstanceParameterNameChars = serviceType.Name.ToCharArray();

            serviceInstanceParameterNameChars[0] = char.ToLower(serviceInstanceParameterNameChars[0]);
            var serviceInstanceParameterName = new string(serviceInstanceParameterNameChars);
            var serviceInstanceParameterExpression = Expression.Parameter(typeof(object), serviceInstanceParameterName);
            var parameterArrayParameterExpression = Expression.Parameter(typeof(object[]), "parameters");

            var parameterAccessExpressions = Enumerable.Range(0, orderedParameterTypes.Length)
            .Select(index => Expression.Convert(
                Expression.ArrayIndex(parameterArrayParameterExpression, Expression.Constant(index)),
                orderedParameterTypes[index]
             ));

            var callExpression = Expression.Convert(Expression.Call(Expression.Convert(serviceInstanceParameterExpression, serviceType),
            methodInfo, parameterAccessExpressions), typeof(object));

            var lambda = Expression.Lambda<Func<object, object[], object>>(callExpression, serviceInstanceParameterExpression, parameterArrayParameterExpression);
            Delegate = lambda.Compile();
        }
    }
}
