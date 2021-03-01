using NUnit.Framework;
using System;
using System.Linq;
using Task3;
using TestHelpers;
using TestHelpers.Attributes;
using TestHelpers.Common;
using TestHelpers.IO;

namespace Tests3
{
	[TargetAssembly("Task3")]
	public class OutputTests: TestFixtureBase<OutputTests>
	{
		private Type subjectType;

		[SetUp]
		public void Setup()
		{
			subjectType = ReflectionHelper.FindType("Program");
		}

		[Test]
		[TestCase(10, TestName = "Вывод пирамидки высотой 10")]
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
			Assert.AreNotEqual(spruceFirstLine, -1, $"Вершина пирамидки не найдена");
			string[] spruceActual = consoleOutput[spruceFirstLine..];
			Assert.AreEqual(count, spruceActual.Length, $"Высота пирамидки: ожидалось - {count}, было - {spruceActual.Length}");
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