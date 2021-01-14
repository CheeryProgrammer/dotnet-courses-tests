namespace Tests4
{
	class Spruce
	{
		public string this[int spruceIndex, int total]
			=> string.Concat(new string(' ', total - spruceIndex - 1), new string('*', (spruceIndex + 1) * 2 - 1));
	}
}
