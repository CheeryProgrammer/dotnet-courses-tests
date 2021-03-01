using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestHelpers;
using TestHelpers.Attributes;
using TestHelpers.Common;
using TestHelpers.IO;

namespace Tests5
{
	[TargetAssembly("Task5")]
	public class Task5Tests : TestFixtureBase<Task5Tests>
	{
		private Type subjectType;

		[SetUp]
		public void Setup()
		{
			subjectType = ReflectionHelper.FindType("Program");
		}

		[Test]
		[TestCaseSource(nameof(TestCases))]
		[Timeout(5000)]
		public void ProgramShouldHaveCorrectOutput(TestData<string> testData)
		{
			InputPlanner inputPlanner = new InputPlanner();
			inputPlanner.ScheduleRead(testData.Input[0].ToCharArray());
			using var console = new ConsoleMock();
			console.Schedule(inputPlanner);
			
			ReflectionHelper.ExecuteMain(subjectType);

			string[] output = console.ReadOutputLines();
			string actual = output.Last();

			Assert.AreEqual(testData.Expected, actual, testData.GetErrorMessage(actual));
		}

		public static IEnumerable<TestCaseData> TestCases()
		{
			string testName = "Замена тегов на символ '_'";
			yield return TestData.CreateTestCaseData(
				new[] { "<b>Это</b> текст <i>с</i> <font color=”red”>HTML</font> кодами" },
				"Результат замены: _Это_ текст _с_ _HTML_ кодами",
				testName);
		}
	}
}