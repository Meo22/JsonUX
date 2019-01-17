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
		/// Parses a simple json file and returns values as string array.
		/// </summary>
		/// <param name="json"></param>
		/// <param name="entryPoint"></param>
		/// <returns>A dictionary with string values</returns>
		public static string[] ParseExtended(string json) => ParseExtended(json, null);

		/// <summary>
		/// Parses a simple json file and returns values as string array. <paramref name="rootElement"/> can be defined as root element.
		/// </summary>
		/// <param name="json"></param>
		/// <param name="rootElement"></param>
		/// <returns>A dictionary with string values</returns>
		public static string[] ParseExtended(string json, string rootElement)
		{
			var ret = new List<string>();

			#region Set Json to entryPoint
			if (!string.IsNullOrEmpty(rootElement))
			{
				var _entryPoints = rootElement.Split('/');

				var parsedJson = JObject.Parse(json);

				foreach (var _entryPoint in _entryPoints)
				{
					parsedJson = (JObject)parsedJson[rootElement];
				}

				var results = parsedJson.Children();
				json = JsonConvert.SerializeObject(results);
			}
			#endregion

			dynamic deserializedJson = Deserialize(json);

			foreach (object property in deserializedJson)
			{
				var jo = property as JObject;

				if (jo != null)
				{
					ret.AddRange(GetJObject(jo));
				}

				var jt = property as JToken;

				if (jt != null)
				{
					ret.AddRange(GetJToken(jt));
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
			
			if (jToken is JProperty)
			{
				var jp = (JProperty)jToken;

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

			if (jToken is JValue)
			{
				var jv = (JValue)jToken;

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
			else if (jToken is JObject)
			{
				var jo = (JObject)jToken;

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
