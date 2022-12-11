using iDev.Application.ViewModels;
using iDev.Infra.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace iDev.Application.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly IDevDbContext _dbcontext;

        public GetUserQueryHandler(IDevDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbcontext.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

            if (user == null)
            {
                return null;
            }

            var userViewModel = new UserViewModel(user.FullName, user.Email);
            return userViewModel;
        }
    }
}
