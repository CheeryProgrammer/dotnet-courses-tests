using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestHelpers.Common
{
	[TestFixture]
	public abstract class TestFixtureBase
	{
		protected static ReflectionHelper ReflectionHelper { get; set; }

		[Test]
		[TestCaseSource(nameof(CodeStyleTestCaseSource))]
		[Category("Кодстайл")]
		public void CodeStyleTests(Func<bool> meetCodestyleRule, string errorMessage)
		{
			Assert.IsTrue(meetCodestyleRule(), errorMessage);
		}

		public static IEnumerable<TestCaseData> CodeStyleTestCaseSource()
		{
			var testCases = CodeStyleTestCaseDataFactory.GetMethodsTestCaseData(ReflectionHelper.GetAllTypes());
			return testCases;
		}
	}
}
