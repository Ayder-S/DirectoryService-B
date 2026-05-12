using CSharpFunctionalExtensions;
using Shared.Failures;

namespace DS.Application.Abstractions;

public interface ICommand;

public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    Task<UnitResult<ErrorsList>> Handle(TCommand command, CancellationToken cancellationToken);
}

public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand
{
    Task<Result<TResponse, ErrorsList>> Handle(TCommand command, CancellationToken cancellationToken);
}
