using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EncodingLib
{
	public class TranslatorManager
	{
		private static IList<Translator> Translators { get;}

		static TranslatorManager()
		{
			string jsonData = File.ReadAllText("CharacterMappings.json");
			Translators = JsonConvert.DeserializeObject<IList<Translator>>(jsonData);
		}

		public static Translator GetTranslator(string schema)
		{
			return Translators.FirstOrDefault(t => t.SourceSchemas.Contains(schema));
		}
	}
}
