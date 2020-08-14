using System;

namespace Task4
{
	public class Program
	{
		static void Main(string[] args)
		{
		}

		public static int GetSumOfElementsInEvenPositions(int[,] array)
		{
			int accum=0;
			for(int i=0; i< array.GetLength(0);i++)
			{
				for(int j=0; j< array.GetLength(1);j++)	
				{
					if((i+j)%2 == 0) 
						accum = accum + array[i,j];	
				}
			}
			
			return accum+5;
		}
	}
}
