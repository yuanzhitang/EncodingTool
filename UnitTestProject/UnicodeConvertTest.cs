using System;
using EncodingLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
	[TestClass]
	public class UnicodeConvertTest
	{
		[TestMethod]
		public void UnicodeConvert()
		{
			//string char1 = "\u0160";
			//string source = "我是Czhenya";
			//string src2 = "\u6211\u662f\u0043\u007a\u0068\u0065\u006e\u0079\u0061";
			//var result = EncodingUtil.StringToUnicode(source);
			//Console.WriteLine(Regex.Unescape("\u6211\u7231\u4f60"));

			//var stc = Regex.Unescape("\u6211\u7231\u4f60");

			Assert.AreEqual("4f60", EncodingUtil.ConvertToUnicodeCodePoint('你'));
			Assert.AreEqual('你', EncodingUtil.ConvertUnicodeCodePointToChar("4f60"));

			Assert.AreEqual("0021", EncodingUtil.ConvertToUnicodeCodePoint('!'));
			Assert.AreEqual('!', EncodingUtil.ConvertUnicodeCodePointToChar("0021"));
		}
	}
}
