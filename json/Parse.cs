using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUX.Json
{
	public class Parse
	{
		/// <summary>
		/// Parses a simple json file and returns values as string.
		/// </summary>
		/// <param name="json"></param>
		/// <returns>A dictionary with string values</returns>
		public static Dictionary<string, string> ParseSimple(string json) => ParseSimple(json, null);

		/// <summary>
		/// Parses a simple json file and returns values as string. If variables are in sub-level, <paramref name="entryPoint"/> can be specified.
		/// </summary>
		/// <param name="json"></param>
		/// <param name="entryPoint"></param>
		/// <returns>A dictionary with string values</returns>
		public static Dictionary<string, string> ParseSimple(string json, string entryPoint)
		{
			if(!string.IsNullOrEmpty(entryPoint))
			{
				var _entryPoints = entryPoint.Split('/');

				var parsedJson = JObject.Parse(json);
				
				foreach (var _entryPoint in _entryPoints)
				{
					parsedJson = (JObject)parsedJson[entryPoint];
				}

				var results = parsedJson.Children();
				json = JsonConvert.SerializeObject(results);
			}

			return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
		}
	}
}
