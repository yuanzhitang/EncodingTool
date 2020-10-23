using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingLib
{
	class TranslateSample
	{
		public static void Run()
		{
			var sourceSchema = "Schema1";
			var sourceCharSet = Encoding.GetEncoding("ISO-8859-1");
			var messageBody = GenerateMessageBody();
			
			string decodedString = string.Empty;

			var translator = TranslatorManager.GetTranslator(sourceSchema);
			if (translator != null && translator.IsEffective)
			{
				var xlatedBytes = Encoding.Convert(sourceCharSet, Encoding.Unicode, messageBody);
				var xlatedChars = Encoding.Unicode.GetChars(xlatedBytes);

				foreach (var unicodeChar in xlatedChars)
				{
					var unicodeCP = EncodingUtil.ConvertToUnicodeCodePoint(unicodeChar);

					if (translator.Mappings.TryGetValue(unicodeCP, out string xlatedCharHexDecimal))
					{
						var xlatedChar = translator.TargetEncoding.GetString(EncodingUtil.ConvertHexStringToByteArray(xlatedCharHexDecimal));
						decodedString += xlatedChar;
					}
					else
					{
						decodedString += unicodeChar;
					}
				}
			}
			else
			{
				decodedString = sourceCharSet.GetString(messageBody);
			}


			Console.WriteLine(sourceCharSet.GetString(messageBody));

			Console.WriteLine(Environment.NewLine);

			Console.WriteLine(decodedString);
		}

		private static byte[] GenerateMessageBody()
		{
			var bytes = new byte[256];
			for (byte i = 0; i < byte.MaxValue; i++)
			{
				bytes[i] = i;
			}

			return bytes;
		}
	}
}
