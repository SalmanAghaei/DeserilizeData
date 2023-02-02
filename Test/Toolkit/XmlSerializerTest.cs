using Contract.Dtos;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolkit.Serializer;
using Xunit;

namespace Test.Toolkit
{
    public  class XmlSerializerTest
    {
        [Fact]
        public void Should_Return_OutPut_When_Valid_Data()
        {
            var str = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><root><FirstName>Salman</FirstName><LastName>Aghaei</LastName><Allowance>4000</Allowance><BasicSalary>500000</BasicSalary><Transportation>10000</Transportation><Date>1401112</Date></root>";
            var xmlSerializer = new XmlSerialize();
            var person=xmlSerializer.Desrialize<PersonCreateDto>(str);
            person.FirstName.Should().Be("Salman");
            person.LastName.Should().Be("Aghaei");
            person.Allowance.Should().Be(4000);
            person.BasicSalary.Should().Be(500000);
            person.Transportation.Should().Be(10000);
            person.Date.Should().Be("1401112");
        }
    }
}
