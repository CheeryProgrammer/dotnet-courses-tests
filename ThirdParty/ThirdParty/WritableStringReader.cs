using System;
using System.IO;
using System.Reflection;

namespace ThirdParty
{
	internal class WritableStringReader: StringReader
	{
		private static FieldInfo _length;
		private static FieldInfo _pos;
		private static FieldInfo _s;

		private int Length
		{
			get => (int)_length.GetValue(this);
			set => _length.SetValue(this, value);
		}

		private int Position
		{
			get => (int)_pos.GetValue(this);
			set => _pos.SetValue(this, value);
		}

		private string String
		{
			get => (string)_s.GetValue(this);
			set => _s.SetValue(this, value);
		}

		static WritableStringReader()
		{
			var type = typeof(StringReader);
			_length = type.GetField("_length", BindingFlags.Instance | BindingFlags.NonPublic);
			_pos = type.GetField("_pos", BindingFlags.Instance | BindingFlags.NonPublic);
			_s = type.GetField("_s", BindingFlags.Instance | BindingFlags.NonPublic);
		}

		public WritableStringReader() : base(string.Empty)
		{
		}

		public void Write(string input)
		{
			string remainder = String.Substring(Position);
			Position = 0;
			String = string.Concat(remainder, input);
			Length = String.Length;
		}

		public void WriteLine(string input)
		{
			Write(input + Environment.NewLine);
		}
	}
}
