using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace TestHelpers.Common
{
	internal static class CodeStyleTestCaseDataFactory
	{
		private static BindingFlags All = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

		internal static IEnumerable<TestCaseData> GetMethodsTestCaseData(Type[] types)
		{
			for (int i = 0; i < types.Length; i++)
			{
				Type type = types[i];

				foreach(var method in type.GetMethods(All))
				{
					if (type.FullName.Equals(method.DeclaringType.FullName))
					{
						string errorMessage = $"Метод должен быть назван с прописной буквы: {type.Name}.{method.Name}";
						yield return new TestCaseData((Func<bool>)(() => Char.IsUpper(method.Name[0])), errorMessage)
							.SetName("Название метода");
					}
				}
			}
		}
	}
}
