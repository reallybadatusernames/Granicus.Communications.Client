using System.IO;
using System.Xml;
using System.Text;
using System.Net.Http;
using System.Xml.Serialization;

using Granicus.Infrastructure.Entities;

namespace Granicus.Infrastructure.Helpers
{
    public static class XmlSerializerExtensions
    {
        public static bool IsNillArray(this string value)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(NilClass));
                serializer.Deserialize(new StringReader(value));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string ToXml(this object input, string scheme)
        {
            XmlSerializer ser = new XmlSerializer(input.GetType(), scheme);
            string result = string.Empty;

            using (MemoryStream memStm = new MemoryStream())
            {
                ser.Serialize(memStm, input);

                memStm.Position = 0;
                result = new StreamReader(memStm).ReadToEnd();
            }

            return result;
        }

        public static XmlDocument ToXmlDocument(this object input)
        {
            var document = new XmlDocument();
            var navigator = document.CreateNavigator();

            using (var writer = navigator.AppendChild())
            {
                var serializer = new XmlSerializer(input.GetType());
                serializer.Serialize(writer, input);
            }

            return document;
        }

        public static XmlDocument ToXmlDocument<T>(this T input)
        {
            var document = new XmlDocument();
            var navigator = document.CreateNavigator();

            using (var writer = navigator.AppendChild())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, input);
            }

            return document;
        }

        public static StringContent ToStringContent(this object input, XmlSerializer? serializer = null)
        {
            if (serializer == null)
                serializer = new XmlSerializer(input.GetType());

            using (var sw = new Utf8StringWriter())
            {
                serializer.Serialize(sw, input);
                var serializedString = sw.ToString();

                return new StringContent(serializedString, Encoding.UTF8, "application/xml");
            }
        }

        public static string ToStringSample(this object input, XmlSerializer? serializer = null)
        {
            if (serializer == null)
                serializer = new XmlSerializer(input.GetType());

            using (var sw = new StringWriter())
            {
                serializer.Serialize(sw, input);
                var serializedString = sw.ToString();

                return serializedString;
            }
        }

        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}
