using FinanceBook.Finance.Application.Queries.Results;
using FinanceBook.Finance.Domain;
using FinanceBook.Finance.Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FinanceBook.Finance.Tests.ValueObjects
{
    public class FinanceCollectionTests
    {


        [Fact]
        public void Should_Create_Collection()
        {
            Guid accountId = Guid.NewGuid();
            var list = new List<Group>()
            {
                new Group(accountId, "test1", null, Category.EXPENSE),
                new Group(accountId, "test2", null, Category.EXPENSE),
                new Group(accountId, "test3", null, Category.EXPENSE),
            };

            GroupCollection collection = GroupCollection.New(list);

            collection.Should().NotBeNull();
            collection.List.Should().HaveCount(3);
        }


        [Theory]
        [InlineData(12, 14, 39, 65)]
        [InlineData(16.40, 9.99, 120.50, 146.89)]
        public void Should_Get_Total(decimal first, decimal second, decimal third, decimal expectedResult)
        {
            Guid groupId = Guid.NewGuid();
            var list = new List<Operation>
            {
                new Operation(groupId, "1", first),
                new Operation(groupId, "2", second),
                new Operation(groupId, "3", third)
            };

            OperationCollection collection = OperationCollection.New(list);

            var result = collection.Total();

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Should_Collection_Show_As_Result()
        {
            Guid groupId = Guid.NewGuid();
            var list = new List<Operation>
            {
                new Operation(groupId, "1", 10),
                new Operation(groupId, "2", 11),
                new Operation(groupId, "3", 12)
            };

            OperationCollection collection = OperationCollection.New(list);

            var result = collection.As(x => new OperationResult(x.Id, x.Name, x.Amount));

            result.Should()
                .HaveCount(3);

            result.Should().Equal(list, (x, y) => x.Name == y.Name);

        }
    }
}
