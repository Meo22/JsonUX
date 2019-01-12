using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUX.json
{
	public class Parse
	{
		/// <summary>
		/// Parses a simple json file and returns values as string.
		/// </summary>
		/// <param name="json"></param>
		/// <returns>A dictionary with string values</returns>
		public Dictionary<string, string> ParseSimple(string json)
		{
			return ParseSimple(json, null);
		}

		/// <summary>
		/// Parses a simple json file and returns values as string. If variables are in sub-level, <paramref name="entryPoint"/> can be specified. Parent properties are ignored.
		/// </summary>
		/// <param name="json"></param>
		/// <returns>A dictionary with string values</returns>
		public Dictionary<string, string> ParseSimple(string json, string entryPoint)
		{
			return new Dictionary<string, string>();
		}
	}
}
