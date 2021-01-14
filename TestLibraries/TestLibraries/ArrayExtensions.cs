using System;

namespace TestHelpers
{
	public static class ArrayExtensions
	{
		public static int IndexOf<T>(this T[] array, Func<T, bool> predicate)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (predicate(array[i]))
					return i;
			}
			return -1;
		}
	}
}
