using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using TestHelpers.Data;

namespace TestHelpers
{
	public class ReflectionHelper
	{
		private Assembly assembly;

		private ReflectionHelper(Assembly assembly)
		{
			this.assembly = assembly;
		}

		public Type FindType(string typeName)
		{
			return assembly.DefinedTypes.FirstOrDefault(t => t.Name.Equals(typeName));
		}

		internal Type[] GetAllTypes()
		{
			return assembly.DefinedTypes
				.Where(t => !t.CustomAttributes.Any(attr => attr.AttributeType == typeof(CompilerGeneratedAttribute)))
				.ToArray();			
		}

        public object ExecuteMain(Type type)
        {
            var mainMethod = type.GetMethod("Main", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            var parameter = mainMethod.GetParameters();

            return parameter.Any()
                ? mainMethod.Invoke(null, new object[] { null })
                : mainMethod.Invoke(null, null);
        }

		public object ExecuteStaticMethod(Type type, string methodName, params object[] args)
		{
			var method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
			return method.Invoke(null, args);
		}

		public static ReflectionHelper CreateForAssembly(string assemblyName)
		{
			var assembly = Assembly.Load(assemblyName);
			if (assembly == null)
				throw new ArgumentException($"Cannot find assembly {assemblyName}");

			return new ReflectionHelper(assembly);
		}

        public object SetValueUsingSetter(object o, string property, object value)
        {
            var setter = GetPropertyAccessors(o.GetType(), property).FirstOrDefault(a => a.ReturnType == typeof(void));
            if (setter == null)
                throw new ArgumentNullException($"Cannot find a setter for {o.GetType()} - {property}");

            return setter.Invoke(o, new[] { value });
        }

        public object GetValueUsingGetter(object o, string property)
        {
            var getter = GetPropertyAccessors(o.GetType(), property).FirstOrDefault(a => a.ReturnType != typeof(void));
            if(getter == null)
                throw new ArgumentNullException($"Cannot find a getter for {o.GetType()} - {property}");

            return getter.Invoke(o, null);
        }

        public object ExecuteConstructorWithCorrectParametersOrder(Type type, params ClassData[] parameters)
        {
            var constructor = type
                .GetConstructors()
                .First(c => c.GetParameters().Length == parameters.Length);

            var orderedParameters = PutParametersInCorrectOrder(constructor, parameters).ToArray();

            return constructor.Invoke(orderedParameters);
        }

        public MethodInfo[] GetPropertyAccessors(Type type, string property)
        {
            return type
                .GetProperty(property)
                ?.GetAccessors();
        }

        private IEnumerable<object> PutParametersInCorrectOrder(ConstructorInfo constructor, ClassData[] parameters)
        {
            var parametersList = parameters.ToList();
            foreach (var parameter in constructor.GetParameters())
            {
                var neededParameter =
                    parametersList.FirstOrDefault(p => p.DataName.ToLower() == parameter.Name?.ToLower()) ??
                    parametersList.FirstOrDefault(p => p.DataType == parameter.ParameterType);

                parametersList.Remove(neededParameter);

                yield return neededParameter.Value;
            }
        }
    }
}
