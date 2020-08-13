using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace ThirdParty
{
	internal class ReadableStringWriter: StringWriter
	{
		private static FieldInfo _sb;

		private StringBuilder BufferBuilder => (StringBuilder)_sb.GetValue(this);

		static ReadableStringWriter()
		{
			var type = typeof(StringWriter);
			_sb = type.GetField("_sb", BindingFlags.Instance | BindingFlags.NonPublic);
		}

		public char? Read()
		{
			char? first = null;
			if (BufferBuilder.Length > 0)
			{
				first = BufferBuilder[0];
				BufferBuilder.Remove(0, 1);
			}
			return first;
		}

		public string? ReadLine()
		{
			var startIndex = FindIndexOf(Environment.NewLine);
			if(startIndex >= 0)
			{
				char[] lineArray = new char[startIndex];
				BufferBuilder.CopyTo(0, lineArray, startIndex);
				BufferBuilder.Remove(0, startIndex + Environment.NewLine.Length);
				return new string(lineArray);
			}
			return null;
		}

		private int FindIndexOf(string line)
		{
			for(int i = 0; i <= BufferBuilder.Length - line.Length; i++)
			{
				if(BufferBuilder[i] == line[0])
				{
					for (int j = 0; j < line.Length; j++)
					{
						if (j == line.Length - 1 && BufferBuilder[i + j] == line[j])
							return i;

						if (BufferBuilder[i + j] != line[j])
							break;
					}
				}
			}
			return -1;
		}
	}
}
