using BuisnessLogic.Models;
using Newtonsoft.Json;
using System.Text;

namespace WebErebor.Serializers
{
	public class JsonSerializer<T> : Serializer<T>
	{
		public string FileName(string name)
		{
			return $"{name}.json";
		}

		public byte[] Serialize(List<ReportEntity<T>> entity)
		{
			string reportSerialized = JsonConvert.SerializeObject(entity, Formatting.Indented);
			return Encoding.Default.GetBytes(reportSerialized);
		}
	}
}
