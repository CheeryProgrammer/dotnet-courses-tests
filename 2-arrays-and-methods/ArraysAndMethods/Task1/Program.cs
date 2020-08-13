using System;

namespace Task1
{
	public class Program
	{
		static void Main(string[] args)
		{
			Array array = GenerateArray();
			(int min, int max) = GetMinAndMaxValues(array);
			PrintArray(array);
		}

		public static Array GenerateArray()
		{
			return new int[100];
		}

		public static (int min, int max) GetMinAndMaxValues(Array array)
		{
			int[] arr = (int[])array;
			int min = arr[0];
			int max = arr[0];

			for (int i = 0; i < arr.Length; i++)
			{
				if (min > arr[i])
					min = arr[i];
				if (max < arr[i])
					max = arr[i];
			}

			return (min, max);
		}

		public static void PrintArray(Array array)
		{
			Console.WriteLine(string.Join(", ", (int[])array));
		}
	}
}
