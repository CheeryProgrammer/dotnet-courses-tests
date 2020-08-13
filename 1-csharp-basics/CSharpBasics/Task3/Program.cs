using System;

namespace Task3
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var count = int.Parse(Console.ReadLine());
			for (int i = 1; i < count + 1; i++)
			{
				Console.WriteLine(new string(' ', count - i) + new string('*', i * 2 - 1));
			}
		}
	}
}
