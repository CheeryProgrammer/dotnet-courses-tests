using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestHelpers;
using TestHelpers.Common;
using ThirdParty;

namespace Tests1
{
	public class WordsAverageLengthTests: TestFixtureBase
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
			console.WriteLineToInput(testData.Input);
			ReflectionHelper.ExecuteStaticMethod(subjectType, "Main", new object[] { null });
			string actual = console.ReadAllLines().Last();

			Assert.AreEqual(testData.Expected, actual, testData.GetErrorMessage(actual));
		}

		public static IEnumerable<TestCaseData> TestCases()
		{
			string testName = "Подсчет средней длины слова во введенной строке";
			yield return TestData.CreateTestCaseData("test", "4", testName);
			yield return TestData.CreateTestCaseData("test, testtesttest", "8", testName);
			yield return TestData.CreateTestCaseData("Привет, Мир!", "4.5", testName);
		}
	}
}