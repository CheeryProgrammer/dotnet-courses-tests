using NUnit.Framework;
using System;
using TestHelpers;
using TestHelpers.Attributes;
using TestHelpers.Common;

namespace Tests3
{
	[TargetAssembly("Task3")]
	public class Task3Tests : TestFixtureBase<Task3Tests>
	{
		private Type subjectType;

		[SetUp]
		public void Setup()
		{
			subjectType = ReflectionHelper.FindType("Program");
		}

		[Test]
		public void ProgramOutputShouldNotBeEmpty()
		{
			var console = new StringConsole();
			ReflectionHelper.ExecuteStaticMethod(subjectType, "Main", new object[] { null });
			Assert.Greater(console.ReadAllLines().Length, 0, "Программа не должна иметь пустой вывод");
		}
	}
}