using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace EncodingLib
{
	public class Translator
	{
		public bool IsEffective { get; set; }
		public string Host { get; set; }
		public List<string> SourceSchemas { get; set; }
		public string TargetEncodingName { get; set; }

		private Encoding targetEncoding;
		[JsonIgnore]
		public Encoding TargetEncoding
		{
			get
			{
				if (targetEncoding == null)
				{
					targetEncoding = Encoding.GetEncoding(TargetEncodingName);
				}
				return targetEncoding;
			}
		}
		public List<string> CharMappings { get; set; }

		private Dictionary<string, string> mappings;
		[JsonIgnore]
		public Dictionary<string, string> Mappings
		{
			get
			{
				if (mappings == null)
				{
					mappings = new Dictionary<string, string>();
					foreach (var charMapping in CharMappings)
					{
						var chars = charMapping.Split(':');
						mappings.Add(chars[0], chars[1]);
					}
				}

				return mappings;
			}
		}
	}
}
