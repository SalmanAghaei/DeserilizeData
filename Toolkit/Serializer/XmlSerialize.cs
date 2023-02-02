using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Toolkit.Serializer;

public class XmlSerialize : ISerializeAdapter
{
    public DataType DataType => DataType.Xml;

    public Tout Desrialize<Tout>(string data)
    {
        var xElement = XElement.Parse(data);
        XElement xmlDocumentWithoutNs = RemoveAllNamespaces(xElement);
        XmlSerializer serializer = new XmlSerializer(typeof(Tout));
        return (Tout)serializer.Deserialize(xmlDocumentWithoutNs.CreateReader());
    }


    private static XElement RemoveAllNamespaces(XElement xmlDocument)
    {
        if (!xmlDocument.HasElements)
        {
            XElement xElement = new XElement(xmlDocument.Name.LocalName);
            xElement.Value = xmlDocument.Value;

            foreach (XAttribute attribute in xmlDocument.Attributes())
                xElement.Add(attribute);

            return xElement;
        }
        XElement result = new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        foreach (XAttribute attribute in xmlDocument.Attributes())
            result.Add(attribute);
        return result;
    }

    public string Serialize(object input)
    {
        throw new NotImplementedException();
    }
}
