using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JLIDashboard.Classes.Common
{
    class AggrUtils
    {
        public class Xml
        {
            public static StringBuilder toXmlString<T>(List<T> list)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var xmlObj in list)
                    sb.Append(toXmlString(xmlObj));
                return sb;
            }
            public static StringBuilder toXmlString<T>(IEnumerable<T> list)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var xmlObj in list)
                    sb.Append(toXmlString(xmlObj));
                return sb;
            }
            public static StringBuilder toXmlString<T>(T xmlObj)
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces(); ns.Add("", "");
                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(xmlObj.GetType());
                serializer.Serialize(stringwriter, xmlObj, ns);
                return stringwriter.GetStringBuilder().Remove(0, 40);
            }
        }
    }
}
