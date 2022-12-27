using iDev.Core.Entities;
using iDev.Core.Repositories;
using iDev.Core.Services;
using iDev.Infra.Persistence;
using MediatR;


namespace iDev.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputerSha256Hash(request.Password);    
            var user = new User(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role);

            await _userRepository.AddUserAsync(user);
            
            return user.Id;
        }
    }
}
