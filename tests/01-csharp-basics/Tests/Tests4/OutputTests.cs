using NUnit.Framework;
using System;
using System.Linq;
using TestHelpers;
using TestHelpers.Attributes;
using TestHelpers.Common;
using TestHelpers.IO;

namespace Tests4
{
	[TargetAssembly("Task4")]
	public class OutputTests : TestFixtureBase<OutputTests>
	{
		private Type subjectType;

		[SetUp]
		public void Setup()
		{
			subjectType = ReflectionHelper.FindType("Program");
		}

		[Test]
		[TestCase(10, TestName = "Вывод ёлочки из 10 сегментов")]
		public void SpruceShouldBeInOutput(int count)
		{
			InputPlanner planner = new InputPlanner();
			planner.ScheduleLine(count.ToString());
			using ConsoleMock console = new ConsoleMock();
			console.Schedule(planner);
			ReflectionHelper.ExecuteMain(subjectType);

			string[] consoleOutput = console.ReadOutputLines();
			int spruceFirstLine = consoleOutput
				.IndexOf(line => line.Count(ch => ch.Equals('*')) == 1);
			Assert.AreNotEqual(spruceFirstLine, -1, "Вершина ёлочки не найдена");
			string[] spruceActual = consoleOutput[spruceFirstLine..];

			var expectedHeight = CalculateSpruceHeight(count);
			var actualHeight = spruceActual.Length;

			Assert.AreEqual(expectedHeight, actualHeight, $"Высота ёлочки: ожидалось - {expectedHeight}, было - {actualHeight}");
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
					Assert.AreEqual(spruce[j, count], spruceActual[lineNumber++], $"Ошибка в строке {i}");
				}
			}
		}
	}
}