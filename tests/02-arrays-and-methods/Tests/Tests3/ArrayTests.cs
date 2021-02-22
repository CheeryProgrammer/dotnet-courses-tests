using NUnit.Framework;
using System.Linq;
using TestHelpers.Common;
using TestHelpers.Attributes;
using System;

namespace Tests3
{
	[TargetAssembly("Task3")]
	public class ArrayTests : TestFixtureBase<ArrayTests>
	{
		private Type subjectType;

		[SetUp]
		public void Setup()
		{
			subjectType = ReflectionHelper.FindType("Program");
		}

		[Test]
		[TestCase(TestName = "Метод GetSumOfNonNegativeElements cуществует и подсчитывает сумму неотрицательных элементов")]
		public void ShouldReturnSumOfPositiveElements()
		{
			int[] array = { -5, 56, 0, 69 };
			int expected = array.Where(element => element > 0).Sum();
			var actual = (int)ReflectionHelper.ExecuteStaticMethod(subjectType, "GetSumOfNonNegativeElements", array);
			var testMessage = new TestMessage<int>($"[{string.Join(", ", array)}]", expected, actual);
			Assert.AreEqual(expected, actual, testMessage.ToString());
		}
	}
}