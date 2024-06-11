using Shared.Abstractions;
using Ticketing.Domain.Entities;

namespace Ticketing.Application.Abstractions
{
    public interface IJwtProvider
    {
        Result<string> Generate(User user);
    }
}
