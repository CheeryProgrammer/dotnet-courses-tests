using NUnit.Framework;
using System;
using System.Linq;
using Task3;
using TestHelpers;
using TestHelpers.IO;

namespace Tests3
{
	public class OutputTests
	{
		[Test]
		public void SpruceShouldBeInOutput()
		{
			int count = 10;
			InputPlanner planner = new InputPlanner();
			planner.ScheduleLine(count.ToString());
			using ConsoleMock console = new ConsoleMock();
			console.Schedule(planner);
			Program.Main(null);

			string[] consoleOutput = console.ReadOutputLines();
			int spruceFirstLine = consoleOutput
				.IndexOf(line => line.Count(ch => ch.Equals('*')) == 1);
			Assert.AreNotEqual(spruceFirstLine, -1);
			string[] spruceActual = consoleOutput[spruceFirstLine..];
			Assert.AreEqual(count, spruceActual.Length);
			AssertSpruce(count, spruceActual);
		}

		private void AssertSpruce(int count, string[] spruceActual)
		{
			var spruce = new Spruce();
			for (int i = 0; i < count; i++)
			{
				Assert.AreEqual(spruce[i,count], spruceActual[i], $"Ошибка в строке {i}");
			}
		}
	}
}