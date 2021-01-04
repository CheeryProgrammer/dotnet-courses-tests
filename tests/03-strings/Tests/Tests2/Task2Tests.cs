using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestHelpers;
using TestHelpers.Attributes;
using TestHelpers.Common;
using TestHelpers.IO;

namespace Tests2
{
	[TargetAssembly("Task2")]
	public class Task2Tests : TestFixtureBase<Task2Tests>
	{
		private Type subjectType;

		[SetUp]
		public void Setup()
		{
			subjectType = ReflectionHelper.FindType("Program");
		}

		[Test]
		[TestCaseSource(nameof(TestCases))]
		public void SymbolDuplicationTest(TestData<string> testData)
		{
			InputPlanner planner = new InputPlanner();
			using var console = new ConsoleMock();
			planner.ScheduleLines(testData.Input);
			console.Schedule(planner);

			ReflectionHelper.ExecuteStaticMethod(subjectType, "Main", new object[] { null });
			
			string actual = console.ReadOutputLines().Last();

			Assert.AreEqual(testData.Expected, actual, testData.GetErrorMessage(actual));
		}

		public static IEnumerable<TestCaseData> TestCases()
		{
			string testName = "Удвоение в первой строке символов из второй строки";
			yield return TestData.CreateTestCaseData(new[] { "написать программу, которая", "описание" }, "ннааппииссаать ппроограамму, коотоораая", testName);
			yield return TestData.CreateTestCaseData(new[] { "", "описание" }, "", testName);
		}
	}
}