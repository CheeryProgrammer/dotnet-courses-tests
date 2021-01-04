using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestHelpers;
using TestHelpers.Attributes;
using TestHelpers.Common;
using TestHelpers.IO;

namespace Tests1
{
	[TargetAssembly("Task1")]
	public class WordsAverageLengthTests : TestFixtureBase<WordsAverageLengthTests>
	{
		private Type subjectType;

		[SetUp]
		public void Setup()
		{
			subjectType = ReflectionHelper.FindType("Program");
		}

		[Test]
		[TestCaseSource(nameof(TestCases))]
		public void AverageWordsLengthTest(TestData<string> testData)
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
			string testName = "Подсчет средней длины слова во введенной строке";
			yield return TestData.CreateTestCaseData(new[] { "test" }, "4", testName);
			yield return TestData.CreateTestCaseData(new[] { "test, testtesttest" }, "8", testName);
			yield return TestData.CreateTestCaseData(new[] { "Привет, Мир!" }, "4.5", testName);
		}
	}
}