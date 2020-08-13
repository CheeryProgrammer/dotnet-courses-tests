using NUnit.Framework;
using Task1;
using ThirdParty;

namespace Tests
{
	public class Tests
	{
		public StringConsole StringConsole;

		[SetUp]
		public void Setup()
		{
			StringConsole = new StringConsole();
		}

		[Test]
		public void SquareOf10By20ShouldBe200()
		{
			StringConsole.WriteLineToInput("10");
			StringConsole.WriteLineToInput("20");
			Program.Main(null);
			Assert.AreEqual("200", StringConsole.ReadLineFromOutput());
		}
	}
}