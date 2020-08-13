using NUnit.Framework;
using System.Linq;
using Task1;
using ThirdParty;

namespace Tests1
{
	public class ArrayTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void ArrayGenerationTest()
		{
			var array = Program.GenerateArray();
			Assert.IsNotNull(array);
			Assert.Greater(array.Length, 0);
		}

		[Test]
		public void GetMinAndMaxElementsTest()
		{
			int[] array = { -4, 6, 0, -10, 45, 2, -7 };
			int expectedMin = array.Min();
			int expectedMax = array.Max();
			(int actualMin, int actualMax) = Program.GetMinAndMaxValues(array);
			Assert.AreEqual(expectedMin, actualMin);
			Assert.AreEqual(expectedMax, actualMax);
		}

		[Test]
		public void PrintArrayTest()
		{
			var stringConsole = new StringConsole();
			int[] array = { -4, 6, 0, -10, 45, 2, -7 };
			Program.PrintArray(array);
			var output = stringConsole.ReadLineFromOutput();
			Assert.IsTrue(array.All(element => output.Contains(element.ToString())));
		}
	}
}