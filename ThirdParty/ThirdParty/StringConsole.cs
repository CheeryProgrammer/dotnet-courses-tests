using System;

namespace ThirdParty
{
	public class StringConsole
	{
		private ReadableStringWriter consoleOut;
		private WritableStringReader consoleIn;

		public StringConsole()
		{
			consoleOut = new ReadableStringWriter();
			consoleIn = new WritableStringReader();
			Console.SetOut(consoleOut);
			Console.SetIn(consoleIn);
		}

		public void WriteInput(string input)
		{
			consoleIn.Write(input);
		}

		public void WriteLineToInput(string input)
		{
			consoleIn.WriteLine(input);
		}

		public char? ReadOutput()
		{
			return consoleOut.Read();
		}

		public string? ReadLineFromOutput()
		{
			return consoleOut.ReadLine();
		}
	}
}
