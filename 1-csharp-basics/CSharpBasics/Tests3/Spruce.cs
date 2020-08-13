namespace Tests3
{
	class Spruce
	{
		public string this[int lineIndex, int total]
			=> string.Concat(new string(' ', total - lineIndex), new string('*', lineIndex * 2 - 1));
	}
}
