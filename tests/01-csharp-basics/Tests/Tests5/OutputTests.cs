using NUnit.Framework;
using System;
using TestHelpers.Attributes;
using TestHelpers.Common;
using TestHelpers.IO;

namespace Tests5
{
	[TargetAssembly("Task5")]
	public class OutputTests : TestFixtureBase<OutputTests>
	{
		private Type subjectType;

		[SetUp]
		public void Setup()
		{
			subjectType = ReflectionHelper.FindType("Program");
		}

		[Test]
		public void AssertNumber()
		{
			using ConsoleMock consoleMock = new ConsoleMock();
			ReflectionHelper.ExecuteStaticMethod(subjectType, "Main", new object[] { null });
			Assert.IsTrue((7 << 15 | 7 << 9 | 3 << 6 | 1 << 4).ToString() == consoleMock.ReadOutput().Trim());
		}
	}
}