using System.Xml.Serialization;

namespace Contract.Dtos;

[XmlRoot("root")]
public class PersonDeleteDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Date { get; set; }
}
