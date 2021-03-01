using NUnit.Framework;
using System;
using TestHelpers;
using TestHelpers.Attributes;
using TestHelpers.Common;
using TestHelpers.IO;

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
			using var console = new ConsoleMock();
			ReflectionHelper.ExecuteMain(subjectType);
			string output = console.ReadOutput().Trim();
			Assert.Greater(output.Length, 0, "Программа не должна иметь пустой вывод");
		}
	}
}