using BuisnessLogic.Models;
using System.Text;
using System.Xml.Serialization;

namespace WebErebor.Serializers
{
	public class XMLSerializer<T> : Serializer<T>
	{
		public string FileName(string name)
		{
            return $"{name}.xml";
		}

		public byte[] Serialize(List<ReportEntity<T>> entity)
		{
            string reportSerialize;
            XmlSerializer xml = new XmlSerializer(typeof(List<ReportEntity<T>>));

            using (StringWriter textWriter = new StringWriter())
            {
                xml.Serialize(textWriter, entity);
                reportSerialize = textWriter.ToString();
            }

            return Encoding.Default.GetBytes(reportSerialize);
        }
	}
}
