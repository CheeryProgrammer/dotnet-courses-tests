using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestHelpers;
using TestHelpers.Common;

namespace Tests1
{
	public class WordsAverageLengthTests : TestFixtureBase<WordsAverageLengthTests>
	{
		private Type subjectType;

		static WordsAverageLengthTests()
		{
			ReflectionHelper = ReflectionHelper.CreateForAssembly("Task1");
		}

		[SetUp]
		public void Setup()
		{
			subjectType = ReflectionHelper.FindType("Program");
		}

		[Test]
		[TestCaseSource(nameof(TestCases))]
		public void AverageWordsLengthTest(TestData<string> testData)
		{
			var console = new StringConsole();
			console.WriteAllLinesToInput(testData.Input);
			ReflectionHelper.ExecuteStaticMethod(subjectType, "Main", new object[] { null });
			string actual = console.ReadAllLines().Last();

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