using System;
using System.Collections.Generic;

namespace TestHelpers
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

		public void WriteAllLinesToInput(string[] input)
		{
			Array.ForEach(input, consoleIn.WriteLine);
		}

		public char? ReadOutput()
		{
			return consoleOut.Read();
		}

		public string? ReadLineFromOutput()
		{
			return consoleOut.ReadLine();
		}

		public string[] ReadAllLines()
		{
			List<string> lines = new List<string>();
			string line;
			while ((line = consoleOut.ReadLine()) != null)
				lines.Add(line);
			return lines.ToArray();
		}
	}
}
