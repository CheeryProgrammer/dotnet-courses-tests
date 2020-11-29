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
		public void ForSingleWordShouldReturnItsLength(string input, string expected)
		{
			var console = new StringConsole();
			console.WriteLineToInput(input);
			ReflectionHelper.ExecuteStaticMethod(subjectType, "Main", new object[] { null });
			string actual = console.ReadAllLines().Last();
			string errorMessage = $"{Environment.NewLine}Ввод: '{input}'{Environment.NewLine}Ожидается: '{expected}'{Environment.NewLine}Было: '{actual}'";
			Assert.AreEqual(expected, actual, errorMessage);
		}

		public static IEnumerable<TestCaseData> TestCases()
		{
			string testName = "Подсчет средней длины слова во введенной строке";
			yield return new TestCaseData("test", "4").SetName(testName);
			yield return new TestCaseData("test, testtesttest", "8").SetName(testName);
			yield return new TestCaseData("Привет, Мир!", 4.5.ToString()).SetName(testName);
		}
	}
}