using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingLib
{
	public class EncodingUtil
	{
		/// <summary>
		/// Convert Char to Unicode Code Point
		/// For e.g Character "Š", Unicode Code page is \u0160
		/// </summary>
		/// <param name="character"></param>
		/// <returns></returns>
		public static string ConvertToUnicodeCodePoint(char character)
		{
			//var bytes = Encoding.Unicode.GetBytes(new char[] { character });

			//var lowerByte = bytes[0];
			//var uppperByte = bytes[1];

			//string codepoint = uppperByte.ToString("X2") + lowerByte.ToString("X2");
			//return codepoint;

			return string.Format("{0:x4}", (int)character);
		}

		/// <summary>
		/// Convert Char to Unicode Code Point
		/// For e.g Unicode Code page is \u0160, The output is Character "Š"
		/// </summary>
		/// <param name="character"></param>
		/// <returns></returns>
		public static char ConvertUnicodeCodePointToChar(string unicodeCodePoint)
		{
			//var lowerByte = Convert.ToByte(unicodeCodePoint.Substring(0, 2), 16);
			//var uppperByte = Convert.ToByte(unicodeCodePoint.Substring(2, 2), 16);
			//var bytes = new byte[] { uppperByte, lowerByte};

			//return Encoding.Unicode.GetChars(bytes)[0];

			return (char)int.Parse(unicodeCodePoint, System.Globalization.NumberStyles.HexNumber);
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
