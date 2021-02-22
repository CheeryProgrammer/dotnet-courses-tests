using Task4;
using NUnit.Framework;
using TestHelpers.Attributes;
using TestHelpers.Common;
using System;
using TestHelpers;

namespace Tests4
{
	[TargetAssembly("Task4")]
	public class Tests : TestFixtureBase<Tests>
	{
		private Type subjectType;

		[SetUp]
		public void Setup()
		{
			subjectType = ReflectionHelper.FindType("Program");
		}

		[Test]
		[TestCase(TestName = "Метод GetSumOfElementsOnEvenPositions должен существовать и правильно считать сумму элементов на четных позициях")]
		public void CalculateSumOfElementsOnEvenPosistions()
		{
			int[,] array =
			{
				{ 4, 7, 1, 8, 5, 2, 8 },
				{ 9, 2, 1, 0, 4, 1, 9 },
				{ 1, 7, 0, 1, 7, 1, 9 }
			};

			int expected = 38;


			int actual = (int)ReflectionHelper.ExecuteStaticMethod(subjectType, "GetSumOfElementsOnEvenPositions", array);

			var testMessage = new TestMessage<int>(array.ToStringRepresentation(), expected, actual);

			Assert.AreEqual(expected, actual, testMessage.ToString());
		}
	}
}