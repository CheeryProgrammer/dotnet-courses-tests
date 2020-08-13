using System;

namespace Task4
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int count = int.Parse(Console.ReadLine());

			for (int i = 1; i <= count; i++)
			{
				for (int j = 1; j <= i; j++)
				{
					Console.WriteLine(string.Concat(new string(' ', count - j), new string('*', j * 2 - 1)));
				}
			}
		}
	}
}
