using Contract.Dtos;
using FluentAssertions;
using Toolkit.Serializer;
using Xunit;

namespace Test.Toolkit
{
    public class CustomSerializerTest
    {
        [Fact]
        public void Should_Return_OutPut_When_Valid_Data()
        {
            var str = "FirstName/LastName/BasicSalary/Allowance/Transportation/Date\nAli/Ahmadi/1200000/400000/350000/14010801";
            var customeSerialize = new CustomSerialize();
            var person= customeSerialize.Desrialize<PersonCreateDto>(str);
            person.FirstName.Should().Be("Ali");
            person.LastName.Should().Be("Ahmadi");
            person.Allowance.Should().Be(400000);
            person.BasicSalary.Should().Be(1200000);
            person.Transportation.Should().Be(350000);
            person.Date.Should().Be("14010801");
        }
    }
}
