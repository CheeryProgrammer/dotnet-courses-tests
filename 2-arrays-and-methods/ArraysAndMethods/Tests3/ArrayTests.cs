using Task3;
using NUnit.Framework;
using System.Linq;

namespace Tests3
{
	public class ArrayTests
	{
		[Test]
		public void ShouldReturnSumOfPositiveElements()
		{
			int[] array = { -5, 56, 0, 69 };
			int expected = array.Where(element => element > 0).Sum();
			int actual = Program.GetSumOfPositiveElements(array);
			Assert.AreEqual(expected, actual);
		}
	}
}