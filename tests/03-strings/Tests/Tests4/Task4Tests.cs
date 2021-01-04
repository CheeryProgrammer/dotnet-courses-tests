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
	public class Task4Tests : TestFixtureBase<Task4Tests>
	{
		private Type subjectType;

		[SetUp]
		public void Setup()
		{
			subjectType = ReflectionHelper.FindType("Program");
		}

		[Test]
		[TestCase(null, TestName = "Сравнение производительности String и StringBuilder")]
		[Timeout(10000)]
		public void ProgramShouldHaveCorrectOutput(object dummy)
		{
			using var console = new ConsoleMock();
			ReflectionHelper.ExecuteStaticMethod(subjectType, "Main", new object[] { null });

			string expectedOutput = $"String: [number]{Environment.NewLine}StringBuilder: [number]";

			string[] lines = console.ReadOutputLines();

			Assert.Greater(lines.Length, 1, $"Ожидаемый вывод:{Environment.NewLine}{expectedOutput}");
			Assert.IsTrue(lines[0].StartsWith("String: "), $"Ожидаемый вывод:{Environment.NewLine}{expectedOutput}");
			Assert.IsTrue(lines[1].StartsWith("StringBuilder: "), $"Ожидаемый вывод:{Environment.NewLine}{expectedOutput}");

			double stringDuration = double.Parse(lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Last());
			double stringBuilderDuration = double.Parse(lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Last());

			Assert.Greater(stringDuration, stringBuilderDuration, "Конкатенация строки не может быть эффективнее класса StringBuilder");
		}
	}
}