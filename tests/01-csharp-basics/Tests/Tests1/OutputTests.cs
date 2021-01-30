using NUnit.Framework;
using System;
using System.Linq;
using TestHelpers.Attributes;
using TestHelpers.Common;
using TestHelpers.IO;

namespace Tests
{
	[TargetAssembly("Task1")]
	public class Tests: TestFixtureBase<Tests>
	{
		private Type subjectType;

		[SetUp]
		public void Setup()
		{
			subjectType = ReflectionHelper.FindType("Program");
		}

		[Test]
		public void SquareOf10By20ShouldBe200()
		{
			InputPlanner planner = new InputPlanner();
			planner.ScheduleLine("10");
			planner.ScheduleLine("20");
			using var consoleMock = new ConsoleMock();
			consoleMock.Schedule(planner);

			ReflectionHelper.ExecuteStaticMethod(subjectType, "Main", new object[] { null });
			Assert.AreEqual("200", consoleMock.ReadOutputLines().Last());
		}
	}
}