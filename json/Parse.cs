using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUX.Json
{
	public static class Parse
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
			if (!string.IsNullOrEmpty(entryPoint))
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

		public static string[] ParseExtended(string json) => ParseExtended(json, null);

		public static string[] ParseExtended(string json, string entryPoint)
		{
			var ret = new List<string>();

			#region Set Json to entryPoint
			if (!string.IsNullOrEmpty(entryPoint))
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
			#endregion

			dynamic deserializedJson = Deserialize(json);

			foreach (object property in deserializedJson)
			{
				if (property is JObject jo)
				{
					ret.AddRange(GetJObject(jo));
				}
				else if (property is JToken jp)
				{
					ret.AddRange(GetJToken(jp));
				}
				else
				{
					ret.Add($"Err: Type not implemented: {property.GetType()}");
				}

			}

			return ret.ToArray();
		}

		private static IList<string> GetJObject(JObject jObject, int level = 0)
		{
			var ret = new List<string>();

			if (jObject.HasValues)
			{
				foreach (JToken child in jObject.Children())
				{
					ret.AddRange(GetJToken(child, level));
				}
			}

			return ret;
		}

		private static IList<string> GetJToken(JToken jToken, int level = 0)
		{
			var ret = new List<string>();
			
			if (jToken is JProperty jp)
			{
				ret.Add($"{new string('\t', level)}{jp.Name}");

				ret.AddRange(GetJValueOrJArray(jp.Value, level));
			}
			else
			{
				ret.AddRange(GetJValueOrJArray(jToken, level));
			}

			return ret;
		}

		private static IList<string> GetJValueOrJArray(JToken jToken, int level)
		{
			var ret = new List<string>();

			if (jToken is JValue jv)
			{
				ret.Add($"{new string('\t', level)}{jv.Value}");
			}
			else if (jToken is JArray)
			{
				level++;
				foreach (var a in jToken)
				{
					ret.AddRange(GetJToken(a, level));
				}

			}
			else if (jToken is JObject jo)
			{
				ret.AddRange(GetJObject(jo, level++));
			}
			else
			{
				ret.Add($"not JValue/JArray/JObject: {jToken.GetType()}");
			}

			return ret;
		}

		private static dynamic Deserialize(string json)
		{
			return JsonConvert.DeserializeObject(json);
		}
	}
}
