using Shared.Abstractions;
using Shared.Abstractions.Messaging;
using System.Security.Cryptography;
using Ticketing.Application.Abstractions;
using Ticketing.Domain.Abstractions;
using Ticketing.Domain.Entities;
using Ticketing.Domain.Errors;

namespace Ticketing.Application.Users.Commands.Login
{
    internal sealed class LoginCommandHandler(
            IRepository repo, IJwtProvider jwtProvider)
        : ICommandHandler<LoginCommand, string>
    {
        private readonly IRepository _repo = repo;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return Error.NullValue(nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return Error.NullValue(nameof(request.Email));
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return Error.NullValue(nameof(request.Password));
            }

            var user = _repo.GetQueryable<User>()
                .Where(u => u.Email.Equals(request.Email))
                .SingleOrDefault();

            if (user == null)
            {
                return UserErrors.NotFound($"{request.Email}");
            }

            var hash = Convert.FromBase64String(user.PasswordHash);
            var salt = Convert.FromBase64String(user.PasswordSalt);

            if (!VerifyPasswordHash(request.Password, hash, salt))
            {
                return new Error("User.Forbidden",
                    "Invalid username or password", 403);
            }

            var tokenResult = _jwtProvider.Generate(user);

            if (!tokenResult.IsSuccess)
            {
                return tokenResult.Error;
            }


            return await Task.FromResult(tokenResult.Value);
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
