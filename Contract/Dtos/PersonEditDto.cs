using System.Xml.Serialization;

namespace Contract.Dtos;

[XmlRoot("root")]
public class PersonEditDto
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public decimal Allowance { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal Transportation { get; set; }
    public string Date { get; set; }
}
