using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace EncodingTool
{
	public class EncodingHelper
	{
		/// <summary>
		/// Convert Char to Unicode Code Point
		/// For e.g Character "Š", Unicode Code page is \u0160
		/// </summary>
		/// <param name="character"></param>
		/// <returns></returns>
		public static string ConvertToUnicodeCodePoint(char character)
		{
			return string.Format("{0:x4}", (int)character);
		}

		/// <summary>
		/// Convert Char to Unicode Code Point
		/// For e.g Unicode Code page is \u0160, The output is Character "Š"
		/// </summary>
		/// <param name="unicodeCodePoint"></param>
		/// <returns></returns>
		public static char ConvertUnicodeCodePointToChar(string unicodeCodePoint)
		{
			return (char)int.Parse(unicodeCodePoint, NumberStyles.HexNumber);
		}

		public static byte[] ConvertHexStringToByteArray(string hex)
		{
			return Enumerable.Range(0, hex.Length)
					.Where(x => x % 2 == 0)
					.Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
					.ToArray();
		}

		public static string StringToUnicode(string source)
		{
			char[] cs = source.ToCharArray();
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < cs.Length; i++)
			{
				sb.AppendFormat("\\u{0:x4}", (int)cs[i]);
			}
			return sb.ToString();
		}
	}
}
