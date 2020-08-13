using NUnit.Framework;
using Task4;
using ThirdParty;

namespace Tests4
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
		public void SpruceShouldBeInOutput()
		{
			int count = 10;
			StringConsole.WriteLineToInput(count.ToString());
			Program.Main(null);
			AssertSpruce(count);
			Assert.IsNull(StringConsole.ReadLineFromOutput());
		}

		private void AssertSpruce(int count)
		{
			var spruce = new Spruce();
			int lineNumber = 0;
			for (int i = 1; i <= count; i++)
			{
				for (int j = 1; j <= i; j++)
				{
					lineNumber++;
					Assert.AreEqual(spruce[j, count], StringConsole.ReadLineFromOutput(), $"Ошибка в строке {lineNumber}");
				}
			}
		}
	}
}