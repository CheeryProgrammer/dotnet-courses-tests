using Task4;
using NUnit.Framework;

namespace Tests4
{
	public class Tests
	{
		[Test]
		public void Test1()
		{
			int[,] array =
			{
				{ 4, 7, 1, 8, 5, 2, 8 },
				{ 9, 2, 1, 0, 4, 1, 9 },
				{ 1, 7, 0, 1, 7, 1, 9 }
			};

			int expected = 38;
			int actual = Program.GetSumOfElementsInEvenPositions(array);

			Assert.AreEqual(expected, actual);
		}
	}
}