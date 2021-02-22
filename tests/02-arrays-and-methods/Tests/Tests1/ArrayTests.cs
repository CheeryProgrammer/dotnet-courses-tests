using NUnit.Framework;
using System;
using System.Linq;
using TestHelpers.Attributes;
using TestHelpers.Common;
using TestHelpers.IO;

namespace Tests1
{

	[TargetAssembly("Task1")]
	public class ArrayTests : TestFixtureBase<ArrayTests>
	{
		private Type subjectType;

		[SetUp]
		public void Setup()
		{
			subjectType = ReflectionHelper.FindType("Program");
		}

		[Test]
		[TestCase(TestName = "Метод GenerateArray существует и создает непустой массив")]
		public void ArrayGenerationTest()
		{
			var array = ReflectionHelper.ExecuteStaticMethod(subjectType, "GenerateArray", null) as int[];
			Assert.IsNotNull(array);
			Assert.Greater(array.Length, 0);
		}

		[Test]
		[TestCase(TestName = "Метод SortAndGetMinAndMaxValues существует и сортирует массив")]
		public void MethodShouldExistAndSortArrayTest()
		{
			int[] array = { -4, 6, 0, -10, 45, 2, -7 };
			var parameters = new object[] { array, 0, 0 };
			var sortedArray = ReflectionHelper.ExecuteStaticMethod(subjectType, "SortAndGetMinAndMaxValues", parameters) as int[];

			for (int i = 0; i < sortedArray.Length - 1; i++)
			{
				Assert.GreaterOrEqual(sortedArray[i + 1], sortedArray[i], $"Массив отсортирован неправильно: [{string.Join(", ", sortedArray)}]");
			}
		}

		[Test]
		[TestCase(TestName = "Метод SortAndGetMinAndMaxValues существует и определяет min и max значения в массиве")]
		public void GetMinAndMaxElementsTest()
		{
			int[] array = { -4, 6, 0, -10, 45, 2, -7 };
			int expectedMin = array.Min();
			int expectedMax = array.Max();
			var parameters = new object[] { array, 0, 0 };
			ReflectionHelper.ExecuteStaticMethod(subjectType, "SortAndGetMinAndMaxValues", parameters);
			int actualMin = (int)(parameters[1]);
			int actualMax = (int)(parameters[2]);
			Assert.AreEqual(expectedMin, actualMin, $"min: ожидалось {expectedMin}, было {actualMin}");
			Assert.AreEqual(expectedMax, actualMax, $"max: ожидалось {expectedMax}, было {actualMax}");
		}

		[Test]
		[TestCase(TestName = "Метод PrintArray существует и выводит элементы в консоль")]
		public void PrintArrayTest()
		{
			using ConsoleMock consoleMock = new ConsoleMock();
			int[] array = { -4, 6, 0, -10, 45, 2, -7 };
			ReflectionHelper.ExecuteStaticMethod(subjectType, "PrintArray", array);
			var output = consoleMock.ReadOutputLines();

			Assert.AreEqual(array.Length, output.Length, $"Число строк в выводе: ожидалось - {array.Length}, было - {output.Length}");

			for (int i = 0; i < array.Length; i++)
			{
				Assert.AreEqual(array[i].ToString(), output[i], $"Вывод элемента массива: ожидалось - {array[i]}, было {output[i]}");
			}
		}
	}
}