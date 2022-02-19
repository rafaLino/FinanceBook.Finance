using FinanceBook.Finance.Application.Commands.CreateGroup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FinanceBook.Finance.Tests.Validators
{
    public class GroupValidatorTests
    {
        [Fact]
        public void Should_Invalidate_CreateGroupCommand_Given_Unknow_Category()
        {
            var command = new CreateGroupCommand
            {
                AccountId = Guid.NewGuid(),
                Name = "Educação",
                Description = null,
                Category = "xxx",
                Amount = 30
            };
            var validator = new CreateGroupCommandValidator();

            var result = validator.Validate(command);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName.Equals("Category"));
        }


        [Theory]
        [InlineData("income")]
        [InlineData("Income")]
        [InlineData("INCOME")]
        [InlineData("Investment")]
        [InlineData("EXPENSE")]
        public void Should_Validate_CreateGroupCommand_Given_Valid_Categories(string category)
        {
            var command = new CreateGroupCommand
            {
                AccountId = Guid.NewGuid(),
                Name = "Educação",
                Description = null,
                Category = category,
                Amount = 30
            };
            var validator = new CreateGroupCommandValidator();

            var result = validator.Validate(command);

            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }
    }
}
