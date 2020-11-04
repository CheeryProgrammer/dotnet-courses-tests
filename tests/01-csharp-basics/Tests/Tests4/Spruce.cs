namespace Tests4
{
	class Spruce
	{
		public string this[int spruceIndex, int total]
			=> string.Concat(new string(' ', total - spruceIndex), new string('*', spruceIndex * 2 - 1));
	}
}
