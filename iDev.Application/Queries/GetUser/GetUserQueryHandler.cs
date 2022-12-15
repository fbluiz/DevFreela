using iDev.Application.ViewModels;
using iDev.Core.Repositories;
using MediatR;

namespace iDev.Application.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);

            if (user == null)
            {
                return null;
            }

            var userViewModel = new UserViewModel(user.FullName, user.Email);
            return userViewModel;
        }
    }
}
