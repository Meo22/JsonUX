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
		private static bool EnableLog { get; set; } = false;

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
				if (property is JToken jt)
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
		
		private void AddJToken(JToken jToken, int level = 0)
		{
			//AddLog($"Enter AddJToken, level {level}");
			
			if(jToken is JObject jo)
			{
				AddLog($"Is JObject, level {level}");

				if (jo.HasValues)
				{
					foreach (JToken child in jo.Children())
					{
						AddJToken(child, level);
					}
				}
			}
			else if (jToken is JProperty jp)
			{
				AddLog($"Is JProperty, level {level}");
				
				Add($"{new string('\t', level)}{jp.Name}");

				//level++;

				AddJToken(jp.Value, level);
			}
			else if (jToken is JValue)
			{
				AddLog($"Is JValue, level {level}");
				
				level++;

				var jv = (JValue)jToken;

				Add($"{new string('\t', level)}{jv.Value}");
			}
			else if (jToken is JArray)
			{
				AddLog($"Is JArray, level {level}");

				level++;
				foreach (var a in jToken)
				{
					AddJToken(a, level);
				}
			}
			else
			{
				AddLog($"Err: Type not implemented: {jToken.GetType()}");
			}
		}

		private static dynamic Deserialize(string json)
		{
			return JsonConvert.DeserializeObject(json);
		}
	}
}
