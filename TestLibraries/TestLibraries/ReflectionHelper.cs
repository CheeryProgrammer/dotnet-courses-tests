using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

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

		public void ExecuteStaticMethod(Type type, string methodName, params object[] args)
		{
			var method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
			method.Invoke(null, args);
		}

		public static ReflectionHelper CreateForAssembly(string assemblyName)
		{
			var assembly = Assembly.Load(assemblyName);
			if (assembly == null)
				throw new ArgumentException($"Cannot find assembly {assemblyName}");

			return new ReflectionHelper(assembly);
		}
	}
}
