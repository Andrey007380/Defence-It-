using System.Xml.Serialization;
using System.IO;

public static class Serializer 
{
    public static string Serialiser<T> (this T toSerial)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        StringWriter writer = new StringWriter();
        xmlSerializer.Serialize(writer, toSerial);
        return writer.ToString();
    }
    public static T DeSerialiser<T>(this string Desetr)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        StringReader reader = new StringReader(Desetr);

        return (T)xmlSerializer.Deserialize(reader);
    }
}
