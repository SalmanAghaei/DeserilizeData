using FluentAssertions;
using System;
using Toolkit.DateTimes;
using Xunit;

namespace Test
{
    public class DateExtentionsTest
    {
        [Fact]
        public void Should_Valid_When_String_Length_8()
        {
            string date = "13991112";
            
            
            var act=DateTimeUtils.ValidDate(date);

            act.Should().Be((1399, 11, 12));
        }


        [Fact]
        public void ValidDateString_Should_false_When_String_Length_More_Than_8()
        {
            string date = "140111123";

            var act = DateTimeUtils.ValidDateString(date);


            act.Should().BeFalse();
        }  
        
        [Fact]
        public void ValidDateString_Should_true_When_String_Length_8()
        {
            string date = "14011123";

            var act = DateTimeUtils.ValidDateString(date);

            act.Should().BeTrue();
        }

    }
}
