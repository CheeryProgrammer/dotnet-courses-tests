namespace Tests3
{
	class Spruce
	{
		public string this[int lineIndex, int total]
			=> string.Concat(new string(' ', total - lineIndex - 1), new string('*', (lineIndex + 1) * 2 - 1));
	}
}
