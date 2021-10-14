using FinanceBook.Finance.Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FinanceBook.Finance.Tests.ValueObjects
{
    public class MonthDateTests
    {
        [Fact]
        public void Should_Create_MonthDate()
        {
            MonthDate first = new MonthDate(2021, 7);
            MonthDate second = MonthDate.Now;
            MonthDate third = DateTime.UtcNow;


            DateTime? fourth = new MonthDate(2021, 6);
            MonthDate nill = null;
            DateTime? fifth = nill;

            first.Should().NotBeNull();
            second.Should().NotBeNull();
            third.Should().NotBeNull();
            fourth.Should().NotBeNull().And.HaveYear(2021).And.HaveMonth(6);
            fifth.Should().BeNull();

        }

        [Fact]
        public void Should_MonthDate_Comparable()
        {
            MonthDate first = new MonthDate(2021, 5);
            MonthDate second = new MonthDate(2021, 3);
            MonthDate third = new MonthDate(2021, 5);

            var list = new List<bool>
            {
                first > second,
                second < first,

                first >= third,
                third <= first,

                first != second,
                first == third
            };

            list.Should().OnlyContain(item => item == true);

        }

        [Fact]
        public void Should_MonthDate_Show_As_String()
        {
            var date = new MonthDate(2021, 10);

            var result = date.ToString();

            result.Should().NotBeEmpty();

            date.Month.Should().Be(10);
            date.Year.Should().Be(2021);
            
        }

        [Fact]
        public void Should_MonthDate_GetHashCode()
        {
            var date = MonthDate.Now;
            var result = date.GetHashCode();
            result.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Should_MonthDate_Equals()
        {
            MonthDate first = new MonthDate(2021, 5);
            MonthDate second = new MonthDate(2021, 5);
            MonthDate third = first;
            MonthDate fourth = null;

            bool r1 = first.Equals(second);
            bool r2 = first.Equals(third);
            bool r3 = first.Equals(fourth);

            r1.Should().BeTrue();
            r2.Should().BeTrue();
            r3.Should().BeFalse();
        }
    }
}
