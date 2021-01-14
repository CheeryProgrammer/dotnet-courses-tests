using NUnit.Framework;
using System;
using System.Linq;
using Task4;
using TestHelpers;
using TestHelpers.IO;

namespace Tests4
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
			Assert.AreEqual(CalculateSpruceHeight(count), spruceActual.Length);
			AssertSpruce(count, spruceActual);
		}

		private double CalculateSpruceHeight(int count)
		{
			if (count == 0)
				return 0;

			return count + CalculateSpruceHeight(count - 1);
		}

		private void AssertSpruce(int count, string[] spruceActual)
		{
			var spruce = new Spruce();
			int lineNumber = 0;
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j <= i; j++)
				{
					Assert.AreEqual(spruce[j, count], spruceActual[lineNumber++], $"Ошибка в строке {lineNumber}");
				}
			}
		}
	}
}