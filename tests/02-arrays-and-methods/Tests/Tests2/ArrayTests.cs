using Task2;
using NUnit.Framework;
using TestHelpers.Attributes;
using TestHelpers.Common;
using System;

namespace Tests2
{
	[TargetAssembly("Task2")]
	public class ArrayTests : TestFixtureBase<ArrayTests>
	{
		private Type subjectType;

		[SetUp]
		public void Setup()
		{
			subjectType = ReflectionHelper.FindType("Program");
		}

		[Test]
		[TestCase(TestName = "Метод ReplacePositiveElementsWithZero существует и заменяет положительные значения нулями")]
		public void MethodShouldReplacePositiveNumbersWithZeros()
		{
			int[,,] expected =
			{
				{
					{-3,0,0,0,0 }, {0,-5,-39,0,0 }
				},
				{
					{-3,0,0,0,0 }, {0,-5,-39,0,0 }
				},
				{
					{-3,0,0,0,0 }, {0,-5,-39,0,0 }
				}
			};

			int[,,] actual =
			{
				{
					{-3,50,39,0,1 }, {6,-5,-39,110,0 }
				},
				{
					{-3,50,39,0,1 }, {6,-5,-39,110,0 }
				},
				{
					{-3,50,39,0,1 }, {6,-5,-39,110,0 }
				}
			};

			ReflectionHelper.ExecuteStaticMethod(subjectType, "ReplacePositiveElementsWithZero", actual);

			AssertAreEqual(expected, actual);

			void AssertAreEqual(int[,,] expected, int[,,] actual)
			{
				Assert.AreEqual(expected.GetLength(0), actual.GetLength(0));
				Assert.AreEqual(expected.GetLength(1), actual.GetLength(1));
				Assert.AreEqual(expected.GetLength(2), actual.GetLength(2));

				for (int i = 0; i < expected.GetLength(0); i++)
				{
					for (int j = 0; j < expected.GetLength(1); j++)
					{
						for (int k = 0; k < expected.GetLength(2); k++)
						{
							Assert.AreEqual(expected[i, j, k], actual[i, j, k], $"[{i}{j}{k}]: ожидалось - {expected[i, j, k]}, было - {actual[i, j, k]}");
						}
					}
				}
			}
		}
	}
}