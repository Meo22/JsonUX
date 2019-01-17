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
		private static bool EnableLog { get; set; } = true;

		IList<string> Result { get; set; }

		public Parse()
		{
			Result = new List<string>();
		}


		private void AddLog(string element)
		{
			if(EnableLog)
				Result.Add(element);
		}

		private void Add(string element)
		{
			Result.Add(element);
		}

		/// <summary>
		/// Parses a simple json file and returns values as string array.
		/// </summary>
		/// <param name="json"></param>
		/// <param name="entryPoint"></param>
		/// <returns>A dictionary with string values</returns>
		public IList<string> ParseExtended(string json) => ParseExtended(json, null);

		/// <summary>
		/// Parses a simple json file and returns values as string array. <paramref name="rootElement"/> can be defined as root element.
		/// </summary>
		/// <param name="json"></param>
		/// <param name="rootElement"></param>
		/// <returns>A dictionary with string values</returns>
		public IList<string> ParseExtended(string json, string rootElement)
		{
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
					AddJObject(jo);
				}

				var jt = property as JToken;

				if (jt != null)
				{
					AddJToken(jt);
				}
				else
				{
					AddLog($"Err: Type not implemented: {property.GetType()}");
				}
			}

			return Result;
		}

		private void AddJObject(JObject jObject, int level = 0)
		{
			AddLog($"Enter AddJObject, level {level}");

			if (jObject.HasValues)
			{
				level++;
				foreach (JToken child in jObject.Children())
				{
					AddJToken(child, level);
				}
			}
		}

		private void AddJToken(JToken jToken, int level = 0)
		{
			AddLog($"Enter GetJToken, level {level}");

			if (jToken is JProperty)
			{
				AddLog($"Is JProperty");

				var jp = (JProperty)jToken;

				Add($"{new string('\t', level)}{jp.Name}");

				level++;

				AddJValueOrJArray(jp.Value, level);
			}
			else
			{
				AddLog($"Is {jToken.GetType()}");

				AddJValueOrJArray(jToken, level);
			}
		}

		private void AddJValueOrJArray(JToken jToken, int level)
		{
			var ret = new List<string>();

			AddLog($"Enter GetJValueOrJArray, level {level}");

			if (jToken is JValue)
			{
				AddLog($"Is JValue");

				var jv = (JValue)jToken;

				Add($"{new string('\t', level)}{jv.Value}");
			}
			else if (jToken is JArray)
			{
				AddLog($"Is JArray");

				level++;
				foreach (var a in jToken)
				{
					AddJToken(a, level);
				}

			}
			else if (jToken is JObject)
			{
				AddLog($"Is JObject");

				var jo = (JObject)jToken;

				AddJObject(jo, level++);
			}
			else
			{
				AddLog($"not JValue/JArray/JObject: {jToken.GetType()}");
			}
		}

		private static dynamic Deserialize(string json)
		{
			return JsonConvert.DeserializeObject(json);
		}
	}
}
