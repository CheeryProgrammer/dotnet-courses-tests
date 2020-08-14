using System;

namespace Task3
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public static int GetSumOfPositiveElements(int[] array)
		{
			int accum = 0;
			for(int i=0;i<array.Length;i++)
			{
				if(array[i] < 0) continue;
				accum = accum + array[i];
			}
			return accum;
		}
	}
}
