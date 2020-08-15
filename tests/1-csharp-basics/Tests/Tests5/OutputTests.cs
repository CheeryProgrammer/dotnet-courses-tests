using NUnit.Framework;
using Task5;
using ThirdParty;

namespace Tests5
{
	public class OutputTests
	{
		private StringConsole StringConsole;
		
		[SetUp]
		public void Setup()
		{
			StringConsole = new StringConsole();
		}

		[Test]
		public void AssertNumber()
		{
			Program.Main(null);
			Assert.IsTrue((7 << 15 | 7 << 9 | 3 << 6 | 1 << 4).ToString() == StringConsole.ReadLineFromOutput());
		}
	}
}