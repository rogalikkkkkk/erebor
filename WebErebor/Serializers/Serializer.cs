using BuisnessLogic.Models;

namespace WebErebor.Serializers
{
    public interface Serializer<T>
    {
        public string FileName(String name);
        public byte[] Serialize(List<ReportEntity<T>> entity);
    }

    public class SerializerFactory
    {
        public static Serializer<T> GetSerializer<T>(Format format)
        {
			return format switch
			{
				Format.Json => new JsonSerializer<T>(),
				Format.XML => new XMLSerializer<T>(),
				_ => throw new Exception("No such exceprion"),
			};
		}
    }

    public enum Format
    {
        Json,
        XML
    }
}
