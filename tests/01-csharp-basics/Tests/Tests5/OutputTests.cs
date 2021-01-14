using NUnit.Framework;
using Task5;
using TestHelpers.IO;

namespace Tests5
{
	public class OutputTests
	{
		[Test]
		public void AssertNumber()
		{
			using ConsoleMock consoleMock = new ConsoleMock();
			Program.Main(null);
			Assert.IsTrue((7 << 15 | 7 << 9 | 3 << 6 | 1 << 4).ToString() == consoleMock.ReadOutput().Trim());
		}
	}
}