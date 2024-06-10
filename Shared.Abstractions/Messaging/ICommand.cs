using MediatR;

namespace Shared.Abstractions.Messaging;

public interface ICommand<TResponse> : IRequest<Result<TResponse>> 
{ }
