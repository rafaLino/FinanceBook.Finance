using FinanceBook.Finance.Application.Commands.CreateGroup;
using FinanceBook.Finance.Application.Commands.CreateGroupWithOperation;
using FinanceBook.Finance.Application.Commands.RemoveGroup;
using FinanceBook.Finance.Application.Commands.UpdateGroup;
using FinanceBook.Finance.Application.Exceptions;
using FinanceBook.Finance.Application.Queries.Results;
using FinanceBook.Finance.Application.Repositories;
using FinanceBook.Finance.Domain;
using FinanceBook.Finance.Domain.ValueObjects;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FinanceBook.Finance.Tests.Commands
{
    public class GroupCommandTests
    {

        private readonly Mock<IGroupWriteOnlyRepository> _groupWriteOnlyRepository;
        private readonly Mock<IGroupReadOnlyRepository> _groupReadOnlyRepository;
        private readonly Mock<IOperationWriteOnlyRepository> _operationWriteOnlyRepository;
        public GroupCommandTests()
        {
            _groupWriteOnlyRepository = new Mock<IGroupWriteOnlyRepository>();
            _groupReadOnlyRepository = new Mock<IGroupReadOnlyRepository>();
            _operationWriteOnlyRepository = new Mock<IOperationWriteOnlyRepository>();
        }


        [Fact]
        public async Task Should_Create_Group()
        {
            var command = new CreateGroupCommand
            {
                AccountId = Guid.NewGuid(),
                Name = "Educação",
                Description = null,
                Category = Category.INCOME
            };

            var _handler = new CreateGroupCommandHandler(_groupWriteOnlyRepository.Object);

            _groupWriteOnlyRepository.Setup(x => x.SaveAsync(It.IsAny<Group>(), CancellationToken.None));

            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.Id.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Should_Remove_Group()
        {
            var command = new RemoveGroupCommand
            {
                Id = Guid.NewGuid()
            };

            var _handler = new RemoveGroupCommandHandler(_groupWriteOnlyRepository.Object);

            _groupWriteOnlyRepository.Setup(x => x.RemoveAsync(command.Id, CancellationToken.None));

            await _handler.Handle(command, CancellationToken.None);

            _groupWriteOnlyRepository.Verify(x => x.RemoveAsync(command.Id, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task Should_Update_Group()
        {
            var group = new Group(Guid.NewGuid(), "Educação", null, Category.EXPENSE);
            var command = new UpdateGroupCommand
            {
                Id = group.Id,
                Name = "Teste",
                Description = "sem descrição"
            };

            var _handler = new UpdateGroupCommandHandler(_groupWriteOnlyRepository.Object, _groupReadOnlyRepository.Object);

            _groupReadOnlyRepository.Setup(x => x.GetAsync(command.Id, CancellationToken.None)).ReturnsAsync(group);
            _groupWriteOnlyRepository.Setup(x => x.UpdateAsync(group, CancellationToken.None));

            await _handler.Handle(command, CancellationToken.None);

            group.Name.Should().Be(command.Name);

            _groupReadOnlyRepository.Verify(x => x.GetAsync(command.Id, CancellationToken.None), Times.Once);
            _groupWriteOnlyRepository.Verify(x => x.UpdateAsync(group, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Group_Not_Found()
        {
            var command = new UpdateGroupCommand
            {
                Id = Guid.NewGuid(),
                Name = "Teste",
                Description = "sem descrição"
            };

            var _handler = new UpdateGroupCommandHandler(_groupWriteOnlyRepository.Object, _groupReadOnlyRepository.Object);

            _groupReadOnlyRepository.Setup(x => x.GetAsync(command.Id, CancellationToken.None)).ReturnsAsync(default(Group));


            await _handler.Invoking(x => x.Handle(command, CancellationToken.None))
                .Should().ThrowAsync<GroupNotFoundException>();

            _groupReadOnlyRepository.Verify(x => x.GetAsync(command.Id, CancellationToken.None), Times.Once);

        }

        [Fact]
        public async Task Should_Create_Group_With_Operation()
        {
            var command = new CreateGroupWithOperationCommand
            {
                AccountId = Guid.NewGuid(),
                Name = "Educação",
                Description = null,
                Category = Category.INCOME,
                Amount = 30
            };

            var _handler = new CreateGroupWithOperationCommandHandler(_groupWriteOnlyRepository.Object, _operationWriteOnlyRepository.Object);

            _groupWriteOnlyRepository.Setup(x => x.SaveAsync(It.IsAny<Group>(), CancellationToken.None));
            _operationWriteOnlyRepository.Setup(x => x.SaveAsync(It.IsAny<Operation>(), CancellationToken.None));

            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.GroupId.Should().NotBeEmpty();
            result.OperationId.Should().NotBeEmpty();
        }

        [Fact]
        public void Should_Create_Finance_Query_Result()
        {
            Guid accountId = Guid.NewGuid();
            var incomes_list = new List<Group>
            {
                Group.Load(Guid.NewGuid(),accountId,"salário",null, Category.INCOME, new List<Operation> { new Operation(Guid.NewGuid(), "salário", 30) }),
                Group.Load(Guid.NewGuid(),accountId,"bônus",null, Category.INCOME, new List<Operation> { new Operation(Guid.NewGuid(), "bônus", 600) }),
                Group.Load(Guid.NewGuid(),accountId,"estorno",null, Category.INCOME, new List<Operation> { new Operation(Guid.NewGuid(), "estorno", 10) })
            };

            var expenses_list = new List<Group>
            {
                Group.Load(Guid.NewGuid(),accountId,"educação",null, Category.EXPENSE, new List<Operation> { new Operation(Guid.NewGuid(), "educação", 90) }),
                Group.Load(Guid.NewGuid(),accountId,"games",null, Category.EXPENSE, new List<Operation> { new Operation(Guid.NewGuid(), "games", 120) }),
                Group.Load(Guid.NewGuid(),accountId,"livros",null, Category.EXPENSE, new List<Operation> { new Operation(Guid.NewGuid(), "livros", 25) }),
            };

            var investments_list = new List<Group>
            {
                Group.Load(Guid.NewGuid(),accountId,"CDB",null, Category.INVESTMENT, new List<Operation> { new Operation(Guid.NewGuid(), "CDB", 90) }),
                Group.Load(Guid.NewGuid(),accountId,"SELIC",null, Category.INVESTMENT, new List<Operation> { new Operation(Guid.NewGuid(), "SELIC", 50) }),
                Group.Load(Guid.NewGuid(),accountId,"LCI",null, Category.INVESTMENT, new List<Operation> { new Operation(Guid.NewGuid(), "LCI", 11) }),
            };

            GroupCollection incomes = GroupCollection.New(incomes_list);
            GroupCollection expenses = GroupCollection.New(expenses_list);
            GroupCollection investments = GroupCollection.New(investments_list);

            var result = new FinanceQueryResult(accountId, incomes, expenses, investments);

            var totalPercentage = result.Balance.BalancePercentage + result.Balance.ExpensePercentage + result.Balance.InvestmentPercentage;

            result.Should().NotBeNull();
            result.AccountId.Should().Be(accountId);

            //Balance
            result.Balance.Should().NotBeNull();
            result.Balance.Income.Should().Be(640);
            result.Balance.Expense.Should().Be(235);
            result.Balance.Investment.Should().Be(151);

            result.Balance.Balance.Should().Be(254);
            result.Balance.Cost.Should().Be(386);
            result.Balance.BalancePercentage.Should().BeApproximately(0.39, 2);
            result.Balance.ExpensePercentage.Should().BeApproximately(0.36, 2);
            result.Balance.InvestmentPercentage.Should().BeApproximately(0.23, 2);
            result.Balance.RemainingIncome.Should().Be(489);

            totalPercentage.Should().Be(1);
        }
    }
}
