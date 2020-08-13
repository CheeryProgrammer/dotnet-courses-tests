using System;

namespace Task2
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public static void ReplacePositiveElementsWithZeros(int[,,] array)
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					for (int k = 0; k < array.GetLength(2); k++)
					{
						if (array[i, j, k] > 0)
							array[i, j, k] = 0;
					}
				}
			}
		}
	}
}
