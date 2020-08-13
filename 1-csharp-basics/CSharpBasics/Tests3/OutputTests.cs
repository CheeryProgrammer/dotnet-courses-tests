using NUnit.Framework;
using Task3;
using ThirdParty;

namespace Tests3
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
			for (int i = 1; i <= count; i++)
			{
				Assert.AreEqual(spruce[i,count], StringConsole.ReadLineFromOutput(), $"Ошибка в строке {i}");
			}
		}
	}
}