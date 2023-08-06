namespace BuberDinner.Application.Authentication.Commands.Register;

using Common.Interfaces.Authentication;
using Common.Interfaces.Persistence;
using Common.Interfaces.Services;

using Domain.Common.Errors;
using Domain.Users;

using ErrorOr;

using MediatR;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;


    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository,
        IDateTimeProvider dateTimeProvider)
    {
        _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command,
        CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = User.SpawnOne(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password,
            _dateTimeProvider.UtcNow,
            _dateTimeProvider.UtcNow);

        _userRepository.Add(user);

        await Task.CompletedTask;
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}