using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestHelpers;
using TestHelpers.Attributes;
using TestHelpers.Common;

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
			var console = new StringConsole();
			console.WriteAllLinesToInput(testData.Input);
			ReflectionHelper.ExecuteStaticMethod(subjectType, "Main", new object[] { null });
			string actual = console.ReadAllLines().Last();

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