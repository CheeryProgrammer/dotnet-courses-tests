using NUnit.Framework;
using System.Linq;
using Task1;
using TestHelpers.IO;

namespace Tests
{
	public class Tests
	{
		[Test]
		public void SquareOf10By20ShouldBe200()
		{
			InputPlanner planner = new InputPlanner();
			planner.ScheduleLine("10");
			planner.ScheduleLine("20");
			using var consoleMock = new ConsoleMock();
			consoleMock.Schedule(planner);

			Program.Main(null);
			Assert.AreEqual("200", consoleMock.ReadOutputLines().Last());
		}
	}
}