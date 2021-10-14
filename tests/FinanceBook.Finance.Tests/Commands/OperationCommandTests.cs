using FinanceBook.Finance.Application.Commands.CreateOperation;
using FinanceBook.Finance.Application.Commands.RemoveOperation;
using FinanceBook.Finance.Application.Commands.UpdateOperation;
using FinanceBook.Finance.Application.Exceptions;
using FinanceBook.Finance.Application.Repositories;
using FinanceBook.Finance.Domain;
using FluentAssertions;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FinanceBook.Finance.Tests.Commands
{
    public class OperationCommandTests
    {
        private readonly Mock<IOperationWriteOnlyRepository> _operationWriteOnlyRepository;
        private readonly Mock<IOperationReadOnlyRepository> _operationReadOnlyRepository;

        public OperationCommandTests()
        {
            _operationWriteOnlyRepository = new Mock<IOperationWriteOnlyRepository>();
            _operationReadOnlyRepository = new Mock<IOperationReadOnlyRepository>();
        }
        [Fact]
        public async Task Should_Create_Operation()
        {
            var command = new CreateOperationCommand
            {
                GroupId = Guid.NewGuid(),
                Name = "dd",
                Amount = 33
            };
            var _handler = new CreateOperationCommandHandler(_operationWriteOnlyRepository.Object);

            _operationWriteOnlyRepository.Setup(x => x.SaveAsync(It.IsAny<Operation>(), CancellationToken.None));

            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.Id.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Should_Remove_Operation()
        {
            var command = new RemoveOperationCommand
            {
                Id = Guid.NewGuid()
            };

            var _handler = new RemoveOperationCommandHandler(_operationWriteOnlyRepository.Object);

            _operationWriteOnlyRepository.Setup(x => x.RemoveAsync(command.Id, CancellationToken.None));

            await _handler.Handle(command, CancellationToken.None);

            _operationWriteOnlyRepository.Verify(x => x.RemoveAsync(command.Id, CancellationToken.None));
        }

        [Fact]
        public async Task Should_Update_Operation()
        {
            var operation = new Operation(Guid.NewGuid(), "aas", 36);
            var command = new UpdateOperationCommand
            {
                Id = operation.Id,
                Amount = 44,
                Name = "lld"
            };

            var _handler = new UpdateOperationCommandHandler(_operationWriteOnlyRepository.Object, _operationReadOnlyRepository.Object);

            _operationReadOnlyRepository.Setup(x => x.GetAsync(command.Id, CancellationToken.None)).ReturnsAsync(operation);

            _operationWriteOnlyRepository.Setup(x => x.UpdateAsync(operation, CancellationToken.None));

            await _handler.Handle(command, CancellationToken.None);

            operation.Name.Should().Be(command.Name);

            _operationReadOnlyRepository.Verify(x => x.GetAsync(command.Id, CancellationToken.None), Times.Once);
            _operationWriteOnlyRepository.Verify(x => x.UpdateAsync(operation, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Operation_Not_Found()
        {
            var command = new UpdateOperationCommand
            {
                Id = Guid.NewGuid(),
                Amount = 44,
                Name = "lld"
            };

            var _handler = new UpdateOperationCommandHandler(_operationWriteOnlyRepository.Object, _operationReadOnlyRepository.Object);

            _operationReadOnlyRepository.Setup(x => x.GetAsync(command.Id, CancellationToken.None)).ReturnsAsync(default(Operation));

            await _handler.Invoking(x => x.Handle(command, CancellationToken.None)).Should().ThrowAsync<OperationNotFoundException>();

            _operationReadOnlyRepository.Verify(x => x.GetAsync(command.Id, CancellationToken.None), Times.Once);
        }
    }
}
