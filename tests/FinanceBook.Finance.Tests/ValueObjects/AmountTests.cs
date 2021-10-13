using FinanceBook.Finance.Domain.ValueObjects;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace FinanceBook.Finance.Tests.ValueObjects
{
    public class AmountTests
    {

        [Fact]
        public void Should_Create_Amount()
        {
            Amount first = new Amount(4);
            Amount second = 5;
            decimal third = new Amount(3);
            Amount fourth = null;
            decimal fourthM = fourth;

            first.Should().NotBeNull();
            second.Should().NotBeNull();
            third.Should().NotBe(null);
            fourthM.Should().Be(0m);
        }

        [Fact]
        public void Should_Amount_Comparable()
        {
            Amount first = 4;
            Amount second = 2;
            Amount third = 4;

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
        public void Should_Amount_Operable()
        {
            Amount first = 2;
            Amount second = 3;
            Amount third = 6;

            var shouldBe_5 = first + second;
            var shouldBe_4 = third - first;
            var shouldBe_2Minus = -first;

            var shouldBe_3 = first;
            var shouldBe_2 = second;
            ++shouldBe_3;
            --shouldBe_2;


            shouldBe_5.Should().Be(5m);
            shouldBe_4.Should().Be(4m);

            shouldBe_2Minus.Should().Be(-2m);
            shouldBe_3.Should().Be(3m);
            shouldBe_2.Should().Be(2m);

        }

        [Fact]
        public void Should_Amount_Show_As_String()
        {
            var amount = new Amount(10);

            amount.ToString().Should().Be("10");
        }

        [Fact]
        public void Should_Amount_GetHashCode()
        {
            Amount amount = 23.5M;
            amount.GetHashCode().Should().BeGreaterThan(0);
        }

        [Fact]
        public void Should_Amount_Equals()
        {
            Amount first = 24;
            Amount second = 24;
            Amount third = first;
            Amount fourth = null;

            bool r1 = first.Equals(second);
            bool r2 = first.Equals(third);
            bool r3 = first.Equals(fourth);

            r1.Should().BeTrue();
            r2.Should().BeTrue();
            r3.Should().BeFalse();
        }

    }
}
