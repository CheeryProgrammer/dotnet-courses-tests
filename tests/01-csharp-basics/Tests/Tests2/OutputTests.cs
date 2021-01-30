using NUnit.Framework;
using System;
using TestHelpers.Attributes;
using TestHelpers.Common;
using TestHelpers.IO;

namespace Tests2
{
	[TargetAssembly("Task2")]
	public class OutputTests: TestFixtureBase<OutputTests>
	{
		private Type subjectType;

		[SetUp]
		public void Setup()
		{
			subjectType = ReflectionHelper.FindType("Program");
		}

		[Test]
		public void SpruceShouldBeInOutput()
		{
			int count = 10;
			InputPlanner planner = new InputPlanner();
			planner.ScheduleLine(count.ToString());
			using ConsoleMock console = new ConsoleMock();
			console.Schedule(planner);

			ReflectionHelper.ExecuteStaticMethod(subjectType, "Main", new object[] { null });

			string[] consoleOutput = console.ReadOutputLines();
			int spruceFirstLine = Array.IndexOf(consoleOutput,"*");
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
				Assert.AreEqual(spruce[i], spruceActual[i], $"Ошибка в строке {i}");
			}
		}
	}
}